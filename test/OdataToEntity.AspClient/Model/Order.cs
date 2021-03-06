﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdataToEntity.Test.Model
{
    public sealed class Customer
    {
        public String Address { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public Sex? Sex { get; set; }
    }

    public sealed class Order
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset? Date { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public String Name { get; set; }
        public OrderStatus Status { get; set; }
    }

    public sealed class OrderItem
    {
        public int? Count { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Decimal? Price { get; set; }
        public String Product { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }

    public sealed class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public String Name { get; set; }

        public Category Parent { get; set; }
        public ICollection<Category> Child { get; set; }
    }

    public enum OrderStatus
    {
        Unknown,
        Processing,
        Shipped,
        Delivering,
        Cancelled
    }

    public enum Sex
    {
        Male,
        Female
    }
}
