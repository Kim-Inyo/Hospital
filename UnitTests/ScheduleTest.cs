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
    public class ScheduleTest
    {
        private readonly ScheduleService _scheduleService;
        private readonly Mock<IScheduleRepository> _scheduleRepositoryMock;

        public ScheduleTest()
        {
            _scheduleRepositoryMock = new Mock<IScheduleRepository>();
            _scheduleService = new ScheduleService(_scheduleRepositoryMock.Object);
        }

        [Fact]
        public void GetScheduleOfDoctorTest()
        {
            _scheduleRepositoryMock.Setup(repository => repository.GetScheduleOfDoctor(
                It.IsAny<int>())).Returns(() => null);

            var res = _scheduleService.GetScheduleOfDoctor(0);
            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Doctor Id", res.Error);
            Assert.Equal("Schedule Not Found", res.Error);
        }

        [Fact]
        public void AddScheduleTest()
        {
            _scheduleRepositoryMock.Setup(repository => repository.AddSchedule(
                It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(() => false);

            var res = _scheduleService.AddSchedule(0, DateTime.MinValue, DateTime.MaxValue);
            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Schedule", res.Error);
        }

        [Fact]
        public void EditScheduleTest()
        {
            _scheduleRepositoryMock.Setup(repository => repository.EditSchedule(
                It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(() => false);

            var res = _scheduleService.EditSchedule(0, DateTime.MinValue, DateTime.MaxValue);
            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Schedule", res.Error);
            Assert.Equal("Invalid Doctor Id", res.Error);
        }
    }
}
