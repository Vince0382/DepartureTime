using System;
using DepartureTime.Classes;
using DepartureTime.Models;

namespace DepartureTime.Interfaces
{
    public interface IDataProvider
    {
        DepartureTimeData GetData();

        DepartureTimeLanguage GetCurrentLanguage();

        Languages GetLanguages();

		void SaveData(DepartureTimeData data, DepartureTimeLanguage language);
    }
}
