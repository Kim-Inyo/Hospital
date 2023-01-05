using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.UseCase;
using Domain.Models;
using Domain.Logic;
using Moq;

namespace UnitTests
{
    public class AppointmentTest
    {
        private readonly AppointmentService _appointmentService;
        private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;

        public AppointmentTest ()
        {
            _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            _appointmentService = new AppointmentService(_appointmentRepositoryMock.Object);
        }

        [Fact]
        public void GetFreeTimeTestBySpec()
        {
            _appointmentRepositoryMock.Setup(repository => repository.GetFreeTime(
                It.IsAny<Spec>())).Returns(() => null);

            var res = _appointmentService.GetFreeTime(new Spec());
            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Spec", res.Error);
        }

        [Fact]
        public void GetFreeTimeTestById()
        {
            _appointmentRepositoryMock.Setup(repository => repository.GetFreeTime(
                It.IsAny<int>())).Returns(() => null);

            var res = _appointmentService.GetFreeTime(0);
            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Doctor ID", res.Error);
        }
    }
}
