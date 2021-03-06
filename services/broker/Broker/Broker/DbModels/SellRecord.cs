﻿namespace Broker.DbModels
{
    public class SellRecord
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string TickerSymbol { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public bool IsSold { get; set; } = false;
    }
}
