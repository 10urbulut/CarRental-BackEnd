using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,
        RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId

                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId

                             join user in context.Users
                             on rental.CustomerId equals user.Id

                             join brand in context.Brands
                             on rental.BrandId equals brand.BrandId

                             join color in context.Colors
                             on rental.ColorId equals color.ColorId

                             select new RentalDetailDto
                             {
                                 CarId = car.CarId,
                                 CustomerId = user.Id,
                                 UserId = user.Id,
                                 RentalId = rental.RentalId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 ModelYear = car.ModelYear,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName
                             };
                return result.ToList();

            }
        }
    }
}
