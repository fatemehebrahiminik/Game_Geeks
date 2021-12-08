using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Services
{
    public class PersonService
    {
        int totalPersonCount = 12;
        List<Person> getPersons()
        {
            return new List<Person>() {
            { new Person() { Image = "/Content/img/japanese_1.jpg", Nationality = Nationalities.Japanese ,Id = 1} },
            { new Person() { Image = "/Content/img/japanese_2.jpg", Nationality = Nationalities.Japanese ,Id = 2} },
            { new Person() { Image = "/Content/img/japanese_3.jpg", Nationality = Nationalities.Japanese ,Id = 3} },
            { new Person() { Image = "/Content/img/Korean_1.jpg", Nationality = Nationalities.Korean ,Id = 4} },
            { new Person() { Image = "/Content/img/Korean_2.jpg", Nationality = Nationalities.Korean,Id = 5 } },
            { new Person() { Image = "/Content/img/Korean_3.jpg", Nationality = Nationalities.Korean ,Id = 6} } ,
            { new Person() { Image = "/Content/img/Chinese_1.jpg", Nationality = Nationalities.Chinese ,Id = 7} },
            { new Person() { Image = "/Content/img/Chinese_2.jpg", Nationality = Nationalities.Chinese ,Id = 8} },
            { new Person() { Image = "/Content/img/Chinese_3.jpg", Nationality = Nationalities.Chinese ,Id = 9} },
            { new Person() { Image = "/Content/img/Thai_1.jpg", Nationality = Nationalities.Thai ,Id = 10} },
            { new Person() { Image = "/Content/img/Thai_2.jpg", Nationality = Nationalities.Thai ,Id = 11} },
            { new Person() { Image = "/Content/img/Thai_3.jpg", Nationality = Nationalities.Thai ,Id = 12} }};

        }

        public ResultModel<int> GetPoint(int boxId, int imgId)
        {
            try
            {
                return new ResultModel<int>((int)getPersons().Where(x => x.Id == imgId).FirstOrDefault().Nationality == boxId ? 20 : -5);
            }
            catch (Exception e)
            {
                //write exception to log
                return new ResultModel<int>(e);
            }

        }

        int getRandomId()
        {
            Random rnd = new Random();
            return rnd.Next(1, totalPersonCount);
        }
        public ResultModel<Person> GetPerson()
        {
            try
            {
                return new ResultModel<Person>(getPersons()[getRandomId()]);
            }
            catch (Exception e)
            {
                //write exception to log
                return new ResultModel<Person>(e);
            }

        }
    }
}
