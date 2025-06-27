using BusinessObjects;
using Service;
using System.Collections.ObjectModel;

namespace WpfApp.ViewModels
{
    public class OrderDetailViewModel
    {
        private readonly OrderDetailService _service;
        public ObservableCollection<OrderDetail> OrderDetails { get; set; }

        public OrderDetailViewModel(OrderDetailService service)
        {
            _service = service;
            OrderDetails = new ObservableCollection<OrderDetail>(_service.GetAll());
        }

        public void Add(OrderDetail detail)
        {
            _service.Add(detail);
            OrderDetails.Add(detail);
        }

        public void Update(OrderDetail detail)
        {
            _service.Update(detail);

        }

        public void Delete(OrderDetail detail)
        {
            _service.Delete(detail.OrderID, detail.ProductID);
            OrderDetails.Remove(detail);
        }
    }
}