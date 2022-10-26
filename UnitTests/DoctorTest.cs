using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Logic;
using Domain.Models;
using Domain.UseCase;
using Moq;


namespace UnitTests
{
    public class DoctorTest
    {
        private readonly DoctorService _doctorService;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

        public DoctorTest()
        {
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _doctorService = new DoctorService(_doctorRepositoryMock.Object);
        }

        [Fact]
        public void AddDoctorTest()
        {
            _doctorRepositoryMock.Setup(repository => repository.AddDoctor(
                It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Spec>())).Returns(() => null);

            var res = _doctorService.AddDoctor(0, "aste", new Spec());

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Doctor", res.Error);
            Assert.Equal("Doctor Exists", res.Error);
        }

        [Fact]
        public void RemoveDoctorTest()
        {
            _doctorRepositoryMock.Setup(repository => repository.RemoveDoctor(
                It.IsAny<int>())).Returns(() => false);

            var res = _doctorService.RemoveDoctor(0);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Id", res.Error);
            Assert.Equal("Doctor not Exists", res.Error);
            Assert.Equal("Failed to remove doctor", res.Error);
        }

        [Fact]
        public void FindDoctorByIdTest()
        {
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(
                It.IsAny<int>())).Returns(() => false);

            var res = _doctorService.FindDoctor(0);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Id", res.Error);
            Assert.Equal("Doctor not found", res.Error);
        }

        [Fact]
        public void FindDoctorBySpecTest()
        {
            _doctorRepositoryMock.Setup(repository => repository.FindDoctor(
                It.IsAny<Spec>())).Returns(() => false);

            var res = _doctorService.FindDoctor(new Spec());

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Spec", res.Error);
            Assert.Equal("Doctor not found", res.Error);
        }
    }
}