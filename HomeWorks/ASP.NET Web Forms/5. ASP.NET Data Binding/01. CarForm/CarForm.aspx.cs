using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.CarForm
{
    public partial class CarForm : System.Web.UI.Page
    {
        private IEnumerable<Producer> producers;
        private IEnumerable<Extra> extras;
        private IEnumerable<string> engineTypes;

        protected void Page_Load(object sender, EventArgs e)
        {
            producers = this.LoadProducers();
            extras = this.LoadExtras();
            engineTypes = this.LoadEngineTypes();

            if (!Page.IsPostBack)
            {
                this.RadioButtonListEngineType.DataSource = engineTypes;

                this.CheckBoxListExtras.DataSource = extras;
                this.CheckBoxListExtras.DataValueField = "Id";
                this.CheckBoxListExtras.DataTextField = "Name";

                this.DropDownListProducer.DataSource = producers;
                this.DropDownListProducer.DataValueField = "Id";
                this.DropDownListProducer.DataTextField = "Name";

                this.DataBind();

                this.DropDownListProducer.Items.Insert(0, new ListItem("", "0"));
            }
        }

        protected void DropDownListProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedProducerId = int.Parse(this.DropDownListProducer.SelectedValue);

            var models = this.producers.FirstOrDefault(p => p.Id == selectedProducerId).Models;

            this.DropDownListModel.DataSource = models;
            this.DropDownListModel.DataValueField = "Id";
            this.DropDownListModel.DataTextField = "Name";
            this.DropDownListModel.DataBind();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            string selectedProducer = "[nothing selected]";
            string selectedModel = "[nothing selected]";
            string selectedEngineType = "[nothing selected]";

            if (DropDownListProducer.SelectedItem != null &&
                !string.IsNullOrEmpty(DropDownListProducer.SelectedItem.Text))
            {
                selectedProducer = DropDownListProducer.SelectedItem.Text;
            }

            if (DropDownListModel.SelectedItem != null)
            {
                selectedModel = DropDownListModel.SelectedItem.Text;
            }

            result.AppendFormat("<strong>Producer: </strong>{0}<br />", Server.HtmlEncode(selectedProducer));
            result.AppendFormat("<strong>Model: </strong>{0}<br />", Server.HtmlEncode(selectedModel));

            IEnumerable<string> selectedExtras = GetSelectedExtras();

            result.Append("<strong>Extras</strong><br />");

            result.Append(string.Join("<br />", selectedExtras));

            if (RadioButtonListEngineType.SelectedItem != null)
            {
                selectedEngineType = RadioButtonListEngineType.SelectedItem.Text;
            }

            result.AppendFormat("<br /><strong>Engine: </strong>{0}", selectedEngineType);

            this.LiteralUserChoice.Text = result.ToString();
        }

        private IEnumerable<Producer> LoadProducers()
        {
            var producers = new List<Producer>()
            {
                new Producer()
                {
                    Id = 1,
                    Name = "BMW",
                    Models = new List<Model>()
                    {
                        new Model()
                        {
                            Id = 1,
                            Name = "M5"
                        },
                        new Model()
                        {
                            Id = 2,
                            Name = "650i"
                        },
                        new Model()
                        {
                            Id = 3,
                            Name = "730d xDrive"
                        },
                        new Model()
                        {
                            Id = 4,
                            Name = "X5"
                        },
                        new Model()
                        {
                            Id = 5,
                            Name = "X6"
                        }
                    }
                },

                new Producer()
                {
                    Id = 2,
                    Name = "Mercedes-Benz",
                    Models = new List<Model>()
                    {
                        new Model()
                        {
                            Id = 1,
                            Name = "970-976 Atego"
                        },
                        new Model()
                        {
                            Id = 2,
                            Name = "963 Actros MP4, Antos"
                        },
                        new Model()
                        {
                            Id = 3,
                            Name = "W230 2001-2011 SL"
                        },
                        new Model()
                        {
                            Id = 4,
                            Name = "W231 2011- SL"
                        },
                        new Model()
                        {
                            Id = 5,
                            Name = "C297 1997 CLK-GTR"
                        }
                    }
                },

                new Producer()
                {
                    Id = 3,
                    Name = "Audi",
                    Models = new List<Model>()
                    {
                        new Model()
                        {
                            Id = 1,
                            Name = "TT RS"
                        },
                        new Model()
                        {
                            Id = 2,
                            Name = "RS7"
                        },
                        new Model()
                        {
                            Id = 3,
                            Name = "A8"
                        },
                        new Model()
                        {
                            Id = 4,
                            Name = "A7"
                        },
                        new Model()
                        {
                            Id = 5,
                            Name = "Q7"
                        }
                    }
                }
            };

            return producers;
        }

        private IEnumerable<Extra> LoadExtras()
        {
            var extras = new List<Extra>()
            {
                new Extra()
                {
                    Id = 1,
                    Name = "Air Conditioning"
                },
                new Extra()
                {
                    Id = 2,
                    Name = "Electric Mirrors"
                },
                new Extra()
                {
                    Id = 3,
                    Name = "Schiebedach"
                },
                new Extra()
                {
                    Id = 4,
                    Name = "Automatic Transmission"
                },
                new Extra()
                {
                    Id = 5,
                    Name = "Self-Heating Seats"
                },
                new Extra()
                {
                    Id = 6,
                    Name = "Satnav"
                },
                new Extra()
                {
                    Id = 7,
                    Name = "Parktronic"
                },
                new Extra()
                {
                    Id = 8,
                    Name = "Cruise Control"
                },
            };

            return extras;
        }

        private IEnumerable<string> LoadEngineTypes()
        {
            var engineTypes = new List<string>()
            {
                "Petrol",
                "Diesel",
                "Electric",
                "Hybrid",
            };

            return engineTypes;
        }

        private IEnumerable<string> GetSelectedExtras()
        {
            List<string> selectedExtras = new List<string>();

            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
            {
                if (this.CheckBoxListExtras.Items[i].Selected)
                {
                    selectedExtras.Add(this.CheckBoxListExtras.Items[i].Text);
                }
            }

            return selectedExtras;
        }
    }
}