using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfAuction.Model
{
    public class AuctionTimer 
    {
        private static DispatcherTimer timer;

        public static void ProductTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        public static void ProductTimerSubscribe(Product product)
        {
            timer.Tick += product.Auction_Tick;

        }

        public static void ProductTimerUnsubscribe(Product product)
        {
            timer.Tick -= product.Auction_Tick;

        }

        public static void ProductTimerStop()
        {
            timer.Stop();
        }
        
    }
}
