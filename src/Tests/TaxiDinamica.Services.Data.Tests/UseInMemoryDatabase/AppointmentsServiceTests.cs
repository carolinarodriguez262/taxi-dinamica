﻿namespace TaxiDinamica.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Data.Appointments;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class AppointmentsServiceTests : BaseServiceTests
    {
        private IAppointmentsService Service => this.ServiceProvider.GetRequiredService<IAppointmentsService>();

        /*
        TODO: Task<T> GetByIdAsync<T>(string id);

        TODO: Task<IEnumerable<T>> GetAllAsync<T>();

        TODO: Task<IEnumerable<T>> GetAllByPartnerAsync<T>(string PartnerId);

        TODO: Task<IEnumerable<T>> GetUpcomingByUserAsync<T>(string userId);

        TODO: Task<IEnumerable<T>> GetPastByUserAsync<T>(string userId);
         */

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            var newGuidId = Guid.NewGuid().ToString();
            await this.CreateAppointmentAsync(newGuidId);

            var dateTime = DateTime.UtcNow.AddDays(5);
            var userId = Guid.NewGuid().ToString();
            var partnerId = Guid.NewGuid().ToString();
            var serviceId = 1;
            var addressStart = Guid.NewGuid().ToString();
            var addressEnd = Guid.NewGuid().ToString();
            var comment = Guid.NewGuid().ToString();
            var price = 123123;

            await this.Service.AddAsync(userId, partnerId, serviceId, dateTime, addressStart, addressEnd, comment, price);

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.Equal(2, appointmentsCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var newGuidId = Guid.NewGuid().ToString();

            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.DeleteAsync(appointment.Id);

            var appointmentsCount = this.DbContext.Appointments.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedAppointment = await this.DbContext.Appointments.FirstOrDefaultAsync(x => x.Id == appointment.Id);
            Assert.Equal(0, appointmentsCount);
            Assert.Null(deletedAppointment);
        }

        [Fact]
        public async Task ConfirmAsyncShouldWorkCorrectly()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.ConfirmAsync(newGuidId);
            var result = await this.DbContext.Appointments.Where(x => x.Id == newGuidId).Select(x => x.Confirmed).FirstOrDefaultAsync();

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.True(result);
        }

        [Fact]
        public async Task DeclineAsyncShouldWorkCorrectly()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.DeclineAsync(newGuidId, "");
            var result = await this.DbContext.Appointments.Where(x => x.Id == newGuidId).Select(x => x.Confirmed).FirstOrDefaultAsync();

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.True(!result);
        }

        [Fact]
        public async Task RateAppointmentShouldWorkCorrectly()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var appointment = await this.CreateAppointmentAsync(newGuidId);

            await this.Service.RateAppointmentAsync(newGuidId);
            var result = await this.DbContext.Appointments.Where(x => x.Id == newGuidId).Select(x => x.IsPartnerRatedByTheUser).FirstOrDefaultAsync();

            var appointmentsCount = await this.DbContext.Appointments.CountAsync();
            Assert.True(result);
        }

        private async Task<Appointment> CreateAppointmentAsync(string newGuidId)
        {
            var appointment = new Appointment
            {
                Id = newGuidId,
                DateTime = DateTime.UtcNow.AddDays(5),
                UserId = Guid.NewGuid().ToString(),
                PartnerId = Guid.NewGuid().ToString(),
                ServiceId = 1,
            };

            await this.DbContext.Appointments.AddAsync(appointment);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Appointment>(appointment).State = EntityState.Detached;
            return appointment;
        }
    }
}
