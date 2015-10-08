﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }
        public List<GoodsRow> goodsList = new List<GoodsRow>();
        public double TotalCost { get; set; }
        public OrderStatus Status { get; set; }
        public List<Comment> comments = new List<Comment>();

        private Order(Customer customer, List<GoodsRow> goods, Comment comment)
        {
            Customer = customer;
            if (goods != null)
            {
                foreach (GoodsRow row in goods)
                {
                    goodsList.Add(row);
                    TotalCost += row.Price;
                }
            }
            comments.Add(comment);
        }
    }
}
