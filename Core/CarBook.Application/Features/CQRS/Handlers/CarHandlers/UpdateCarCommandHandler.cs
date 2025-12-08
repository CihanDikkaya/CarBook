
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {

        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BrandID);
            values.Fuel = command.Fuel;
            values.Transmission = command.Transmission;
            values.BigImageURL = command.BigImageURL;
            values.BrandID = command.BrandID;
            values.CoverImageURL = command.CoverImageURL;
            values.Km = command.Km;
            values.Model = command.Model;
            values.Seat = command.Seat;
            values.Luggage = command.Luggage;


            await _repository.UpdateAsync(values);
        }
    }
}
