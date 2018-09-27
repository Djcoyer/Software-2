using Software2.Models;
using Software2.Services;
using Software2.Views.manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software2.Views.City
{
    public partial class CityListForm : Form
    {

        private CityService cityService;
        private IFormManager _formManager;
        private List<city> cities;

        public CityListForm(CityService cityService, IFormManager formManager)
        {
            this.cityService = cityService;
            _formManager = formManager;
            cities = cityService.findAll();
            InitializeComponent();
            cityGridView.DataSource = cities.Select(c => new
            CityRow
            {
                Id = c.cityId,
                Name = c.city1,
                CountryId = c.countryId,
                Created = c.createDate,
                Updated = c.lastUpdate
            }).ToList();

        }
    }
}
