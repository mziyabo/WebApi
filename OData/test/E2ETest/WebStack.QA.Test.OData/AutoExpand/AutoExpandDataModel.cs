﻿using System.Data.Entity;
using System.Web.OData.Builder;

namespace WebStack.QA.Test.OData.AutoExpand
{
    public class AutoExpandContext : DbContext
    {
        public static string ConnectionString =
            @"Data Source=(LocalDb)\v11.0;Integrated Security=True;Initial Catalog=AutoExpandTest";

        public AutoExpandContext()
            : base(ConnectionString)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<NormalOrder> NormalOrders { get; set; }
    }

    public class People
    {
        public int Id { get; set; }

        [AutoExpand]
        public Order Order { get; set; }

        public People Friend { get; set; }
    }

    [AutoExpand]
    public class Customer
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public Customer Friend { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }

        [AutoExpand]
        public ChoiceOrder Choice { get; set; }
    }

    public class ChoiceOrder
    {
        public int Id { get; set; }

        public double Amount { get; set; }
    }

    public class SpecialOrder : Order
    {
        [AutoExpand]
        public ChoiceOrder SpecialChoice { get; set; }
    }

    public class VipOrder : SpecialOrder
    {
        [AutoExpand]
        public ChoiceOrder VipChoice { get; set; }
    }

    public class NormalOrder
    {
        public int Id { get; set; }
    }

    public class DerivedOrder : NormalOrder
    {
        [AutoExpand]
        public OrderDetail OrderDetail { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
