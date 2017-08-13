using System;

namespace BusinessLogicLayerInterfaces.DataTransferObjects
{
    public class ReviewDTO
    {
        public string Id { get; set; }
        public string Authorname { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}