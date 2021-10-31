using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAllOrders();
        IDataResult<List<Order>> GetAllByCustomerId(string customerId);
        IDataResult<List<Order>> GetAllByEmployeeId(int employeeId);
        IDataResult<List<Order>> GetAllByOrderDate(DateTime orderDate);
        IDataResult<List<OrderDetailDto>> GetOrderDetails();
        IResult Add(Order p);
        IResult Update(Order p);
    }
}
