using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public static int ClientCount { get; set; } = 0;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IOrderDetailService orderDetailService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_orderDetailService = orderDetailService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}

		public async Task SendStatistic()
        {
            var value1 = _categoryService.BusinnesGetListAll().Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value1);

            var value2 = _productService.BusinessProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.BusinessCategoryActiveCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.BusinessCategoryPassiveCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.BusinnessProductCountByCategoryName(1);
            await Clients.All.SendAsync("ReceiveHamburgerCategoryProductCount", value5);

            var value6 = _productService.BusinnessProductCountByCategoryName(5);
            await Clients.All.SendAsync("ReceiveDrinkCategoryProductCount", value6);

            var value7=_productService.BusinessProductAvgPrice();
            await Clients.All.SendAsync("ReceiveAvgProductPrice", value7.ToString("0.00") + " TL");

            var value8 = _productService.MaxPriceProductName();
            await Clients.All.SendAsync("ReciveMaxProductName", value8);

            var value9 = _productService.MinPriceProductName();
            await Clients.All.SendAsync("ReciveMinPriceProductName", value9);

            var value10 = _productService.BusinnessGetCategoryAvgPrice(1);
            await Clients.All.SendAsync("ReciveHamburgerCategoryProductAvgPrice", value10.ToString("0.00")+" TL");

            var value11 = _orderService.BusinessTotalOrderCount();
            await Clients.All.SendAsync("ReciveTotalOrderCount", value11);

            var value12 = _orderService.BusinessActiveOrderCount();
            await Clients.All.SendAsync("ReciveActiveOrderCount", value12);

            var value13 = _orderService.BusinessLastOrderPrice();
            await Clients.All.SendAsync("ReciveLastOrderPrice", value13.ToString("0.00") + "  TL");

            var value14 = _moneyCaseService.BusinessTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReciveTotalMoneyCaseAmount", value14);

            var value15 = _orderService.BusinessTodayTotalPrice();
            await Clients.All.SendAsync("ReciveTodayTotalPrice", value15.ToString("0.00") + "  TL");

            var value16 = _menuTableService.BusinessMenuTableCount();
            await Clients.All.SendAsync("ReciveMenuTableCount", value16);


        }

        public async Task SendProgress()
        {
            var value1 = _orderService.BusinessTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value1.ToString("0.00")+" TL");

            var value2 = _orderService.BusinessActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            var value3 = _menuTableService.BusinessMenuTableCount();
            await Clients.All.SendAsync("ReceiveBusinessMenuTableCount", value3);

            var value4=_menuTableService.BusinessActiveMenuTableCount();
            await Clients.All.SendAsync("ReceiveBusinessActiveMenuTableCount", value4);

            var value5 = _menuTableService.BusinessPassiveMenuTableCount();
            await Clients.All.SendAsync("ReceiveBusinessPassiveMenuTableCount", value5);
        }


        public async Task GetBookingList()
        {
            var values=_bookingService.BusinnesGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.BusinessNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var notificationListByFalse = _notificationService.BusinnessGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
        }

        public async Task SendMenuTableList()
        {
            var value = _menuTableService.BusinnesGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableList", value);
        }

        public async Task SendMessage(string user , string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",user,message);
        }

        public override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReseiveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReseiveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
