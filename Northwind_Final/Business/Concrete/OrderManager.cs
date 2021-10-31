using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order p)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Order p)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Order>> GetAllByCustomerId(string customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.CustomerId == customerId));
        }



        public IDataResult<List<Order>> GetAllByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.EmployeeId == employeeId));
        }



        public IDataResult<List<Order>> GetAllByOrderDate(DateTime orderDate)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.OrderDate == orderDate));
        }



        public IDataResult<List<Order>> GetAllOrders()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }


        public IDataResult<List<OrderDetailDto>> GetOrderDetails()
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_orderDal.GetOrderDetails());
        }

    }
}
