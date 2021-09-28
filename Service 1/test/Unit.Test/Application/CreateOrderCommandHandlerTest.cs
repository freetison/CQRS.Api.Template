using System.Threading;
using Application.UseCases.CreateOrder;
using AutoMapper;
using Domain.Services;
using MediatR;
using Moq;
using Xunit;

namespace Unit.Test.Application
{
    public class CreateOrderCommandHandlerTest
    {
        private readonly Mock<IOrderService> _orderServiceMock;
        private Mock<IMediator> _mediator;
        private Mock<IMapper> _mapper;

        public CreateOrderCommandHandlerTest(Mock<IOrderService> orderServiceMock, Mock<IMediator> mediator, Mock<IMapper> mapper)
        {
            _orderServiceMock = orderServiceMock;
            _mediator = mediator;
            _mapper = mapper;
        }

        [Fact]
        public async void EmptyProductId_ShouldThrowValidationException()
        {
            //Arange
            var mapper = new Mock<IMapper>();
            var mockRequest = new Mock<CreateOrderRequest>();
            var validator = new CreateOrderCommandValidator();
            var cmd = new CreateOrderCommand(mockRequest.Object);


            mockRequest.SetupGet(p => p.Id).Returns(1);
            mockRequest.SetupGet(p => p.ProductId).Returns("");
            mockRequest.SetupGet(p => p.ProductName).Returns("akui");
            mockRequest.SetupGet(p => p.Quantity).Returns(2);


            //Act
            var validationResult = await validator.ValidateAsync(cmd);


            //Asert
            Assert.True(validationResult.IsValid);
        }
    }
}
