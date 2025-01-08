//using Microsoft.EntityFrameworkCore;
//using RespositoryLayer.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Net.WebRequestMethods;

//namespace RespositoryLayer.ContextDB
//{
//    public class BookEcommerceContext : DbContext
//    {
//        public BookEcommerceContext(DbContextOptions<BookEcommerceContext> options) : base(options) { }

//        public DbSet<Category> Categories { get; set; }
//        public DbSet<Product> Products { get; set; }
//        public DbSet<Cart> Carts { get; set; }
//        public DbSet<CartItem> CartItems { get; set; }
//        public DbSet<User> Users { get; set; }
//        public DbSet<Order> Orders { get; set; }
//        public DbSet<OrderItem> OrderItems { get; set; }
//        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
//        public DbSet<Transaction> Transactions { get; set; }
//        //public DbSet<Wishlist> Wishlists { get; set; }
//        //public DbSet<Review> Reviews { get; set; }
//        //public DbSet<OTP> OTPs { get; set; }
//        //public DbSet<Chat> Chats { get; set; }
//        //public DbSet<ProductImage> ProductImages { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Configure Cart to User (UserId)
//            modelBuilder.Entity<Cart>()
//                .HasOne(c => c.User)
//                .WithMany(u => u.Carts)
//                .HasForeignKey(c => c.UserId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Configure CartItem to Cart (CartId)
//            modelBuilder.Entity<CartItem>()
//                .HasOne(ci => ci.Cart)
//                .WithMany(c => c.CartItems)
//                .HasForeignKey(ci => ci.CartId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Configure CartItem to Product (ProductId)
//            modelBuilder.Entity<CartItem>()
//                .HasOne(ci => ci.Product)
//                .WithMany()
//                .HasForeignKey(ci => ci.ProductId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Configure Order to User (UserId)
//            modelBuilder.Entity<Order>()
//                .HasOne(o => o.User)
//                .WithMany(u => u.Orders)
//                .HasForeignKey(o => o.UserId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Configure Order to Transaction (TransactionId)
//            modelBuilder.Entity<Order>()
//                .HasOne(o => o.Transaction)
//                .WithMany()
//                .HasForeignKey(o => o.TransactionId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Configure Order to ShippingAddress (ShippingAddressId)
//            modelBuilder.Entity<Order>()
//                .HasOne(o => o.ShippingAddress)
//                .WithMany()
//                .HasForeignKey(o => o.ShippingAddressId)
//                .OnDelete(DeleteBehavior.Restrict);

//            // Configure OrderItem to Order (OrderId)
//            modelBuilder.Entity<OrderItem>()
//                .HasOne(oi => oi.Order)
//                .WithMany(o => o.OrderItems)
//                .HasForeignKey(oi => oi.OrderId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Configure OrderItem to Product (ProductId)
//            modelBuilder.Entity<OrderItem>()
//                .HasOne(oi => oi.Product)
//                .WithMany()
//                .HasForeignKey(oi => oi.ProductId)
//                .OnDelete(DeleteBehavior.Restrict);

//            //// Configure Wishlist to User (UserId)
//            //modelBuilder.Entity<Wishlist>()
//            //    .HasOne(w => w.User)
//            //    .WithMany(u => u.Wishlists)
//            //    .HasForeignKey(w => w.UserId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //// Configure Wishlist to Product (ProductId)
//            //modelBuilder.Entity<Wishlist>()
//            //    .HasOne(w => w.Product)
//            //    .WithMany()
//            //    .HasForeignKey(w => w.ProductId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //// Configure Review to Product (ProductId)
//            //modelBuilder.Entity<Review>()
//            //    .HasOne(r => r.Product)
//            //    .WithMany(p => p.Reviews)
//            //    .HasForeignKey(r => r.ProductId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //// Configure Review to User (UserId)
//            //modelBuilder.Entity<Review>()
//            //    .HasOne(r => r.User)
//            //    .WithMany(u => u.Reviews)
//            //    .HasForeignKey(r => r.UserId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //// Configure OTP to User (UserId)
//            //modelBuilder.Entity<OTP>()
//            //    .HasOne(o => o.User)
//            //    .WithMany(u => u.OTPs)
//            //    .HasForeignKey(o => o.UserId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //// Configure OTP to Cart (CartId)
//            //modelBuilder.Entity<OTP>()
//            //    .HasOne(o => o.Cart)
//            //    .WithMany(c => c.OTPs)
//            //    .HasForeignKey(o => o.CartId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //// Configure Chat to Sender (SenderId)
//            //modelBuilder.Entity<Chat>()
//            //    .HasOne(c => c.Sender)
//            //    .WithMany(u => u.SentChats)
//            //    .HasForeignKey(c => c.SenderId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //// Configure Chat to Receiver (ReceiverId)
//            //modelBuilder.Entity<Chat>()
//            //    .HasOne(c => c.Receiver)
//            //    .WithMany(u => u.ReceivedChats)
//            //    .HasForeignKey(c => c.ReceiverId)
//            //    .OnDelete(DeleteBehavior.Restrict);

//            //base.OnModelCreating(modelBuilder);
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using RespositoryLayer.Entity;
using System;

namespace RespositoryLayer.ContextDB
{
    public class BookEcommerceContext : DbContext
    {
        public BookEcommerceContext(DbContextOptions<BookEcommerceContext> options) : base(options) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        // Uncomment if needed
        //public DbSet<Wishlist> Wishlists { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<OTP> OTPs { get; set; }
        //public DbSet<Chat> Chats { get; set; }
        //public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Cart to User (UserId)
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure CartItem to Cart (CartId)
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure CartItem to Product (ProductId)
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Order to User (UserId)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Order to Transaction (TransactionId)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Transaction)
                .WithMany()
                .HasForeignKey(o => o.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Order to ShippingAddress (ShippingAddressId)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingAddress)
                .WithMany()
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure OrderItem to Order (OrderId)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure OrderItem to Product (ProductId)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Uncomment if needed
            // Configure Wishlist to User (UserId)
            //modelBuilder.Entity<Wishlist>()
            //    .HasOne(w => w.User)
            //    .WithMany(u => u.Wishlists)
            //    .HasForeignKey(w => w.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure Wishlist to Product (ProductId)
            //modelBuilder.Entity<Wishlist>()
            //    .HasOne(w => w.Product)
            //    .WithMany()
            //    .HasForeignKey(w => w.ProductId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure Review to Product (ProductId)
            //modelBuilder.Entity<Review>()
            //    .HasOne(r => r.Product)
            //    .WithMany(p => p.Reviews)
            //    .HasForeignKey(r => r.ProductId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure Review to User (UserId)
            //modelBuilder.Entity<Review>()
            //    .HasOne(r => r.User)
            //    .WithMany(u => u.Reviews)
            //    .HasForeignKey(r => r.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure OTP to User (UserId)
            //modelBuilder.Entity<OTP>()
            //    .HasOne(o => o.User)
            //    .WithMany(u => u.OTPs)
            //    .HasForeignKey(o => o.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure OTP to Cart (CartId)
            //modelBuilder.Entity<OTP>()
            //    .HasOne(o => o.Cart)
            //    .WithMany(c => c.OTPs)
            //    .HasForeignKey(o => o.CartId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure Chat to Sender (SenderId)
            //modelBuilder.Entity<Chat>()
            //    .HasOne(c => c.Sender)
            //    .WithMany(u => u.SentChats)
            //    .HasForeignKey(c => c.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure Chat to Receiver (ReceiverId)
            //modelBuilder.Entity<Chat>()
            //    .HasOne(c => c.Receiver)
            //    .WithMany(u => u.ReceivedChats)
            //    .HasForeignKey(c => c.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
    