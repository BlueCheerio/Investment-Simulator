using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Investment_Simulator
{
    public partial class Form1 : Form
    {
        //The Lists for Events and Investments
        List<Event> Events = new List<Event>();
        List<Investment> Investments = new List<Investment>();
        string[] BadEventNames = new string[] //AI generated names for bad events
        {
            "Market Crash", "Hyper-Inflation", "Supply Chain Collapse", "Bank Run", "Asset Bubble Burst",
            "Trade Embargo", "Currency Devaluation", "Stock Sell-off", "Industrial Strike", "Credit Crunch",
            "Energy Crisis", "Housing Market Slump", "Mass Layoffs", "Interest Rate Spike", "Export Deficit",
            "Corporate Bankruptcy", "Debt Default", "Recession Spiral", "Tax Hike", "Consumer Boycott"
        };
        string[] GoodEventNames = new string[] // AI generated names for good events
        {
            "Market Rally", "Record High Exports", "Technological Breakthrough", "Full Employment", "Bull Market Trend",
            "Trade Agreement Signed", "Currency Stabilization", "Venture Capital Surge", "Tax Incentive Program", "Consumer Confidence Peak",
            "Infrastructure Boom", "Interest Rate Cut", "Industrial Expansion", "Foreign Investment Influx", "Budget Surplus",
            "Startup Explosion", "Energy Independence", "Housing Market Growth", "Debt Relief Package", "Retail Sales Surge"
        };
        //Our variables for the game
        Random generate = new Random();
        int currentSelect;
        int gameTime = 1;
        double money = 1000000;
        public Form1()
        {
            //Initialize the investments and WinForms
            string[] investmentNames = new string[] // My AI generated company names that can be used for any investment
            {
                "Apex Solutions", "Blue Horizon Tech", "Crystal Logistics", "Delta Dynamics", "Evergreen Ventures",
                "Frontier Systems", "Global Nexus", "Helix Industries", "Ironclad Security", "Jupiter Media",
                "Keystone Partners", "Liberty Financial", "Mountain Peak Co", "Nova Robotics", "Oceanic Imports",
                "Pinnacle Group", "Quantum Labs", "Radiant Energy", "Summit Enterprise", "Terra Firma",
                "Unity Software", "Velocity Labs", "Western Crest", "Xenon Electronics", "Yield Growth",
                "Zodiac Consulting", "Alpha Stream", "Bright Path", "Cloud Nine", "Deep Blue Inc",
                "Echo Communications", "First Light", "Gold Standard", "High Tide", "Infinite Loop",
                "Jade Dragon", "Kestrel Aviation", "Level Up", "Master Craft", "Night Owl",
                "Orbit Space", "Prime Choice", "Quick Silver", "Red Rock", "Silver Lining",
                "Titan Heavy", "Urban Pulse", "Vista Point", "Wild Card", "Zenith Point",
                "Acme Innovations", "Bridge City", "Cedar Ridge", "Dune Travelers", "Eagle Eye",
                "Falcon Wing", "Grand View", "Hidden Gem", "Island Breeze", "Jump Start",
                "Kindred Spirits", "Lone Star", "Maple Leaf", "Northern Star", "Open Door",
                "Pacific Rim", "Quiet Storm", "Rising Sun", "Stone Bridge", "Twin Peaks",
                "Underwood Co", "Valley Forge", "Windjammer", "Yellowstone", "Zephyr Inc",
                "Anchor Point", "Beacon Hill", "Copper Canyon", "Diamond Edge", "Emerald Isle",
                "Frost Bite", "Green Garden", "Harbor Light", "Indigo Sky", "Jungle Beat",
                "King's Court", "Lemon Tree", "Mystic River", "North Wind", "Orange Grove",
                "Purple Haze", "Quartz Crystal", "River Run", "Sky High", "Timber Land",
                "Upland Park", "Velvet Touch", "White Water", "X-Factor", "Young Blood"
            };
            //Our potential Investment types, These classes, combined with the Investment parent class and Event class make up my 8 total classes in additon to Program and Form1
            string[] InvestmentClasses = {
                "Stock",
                "PennyStock",
                "Bank",
                "Crypto",
                "DividendStock",
                "ETF"
            };

            for (int i = 0; i < 9; i++)
            {
                //Create our Instances of the Investments (it is randomized)
                string classType = InvestmentClasses[generate.Next(InvestmentClasses.Length)];
                if (classType == "Stock")
                {
                    Investments.Add(new Stock(investmentNames[generate.Next(investmentNames.Length)]));
                }
                else if (classType == "PennyStock")
                {
                    Investments.Add(new PennyStock(investmentNames[generate.Next(investmentNames.Length)]));
                }
                else if (classType == "Bank")
                {
                    Investments.Add(new Bank(investmentNames[generate.Next(investmentNames.Length)]));
                }
                else if (classType == "Crypto")
                {
                    Investments.Add(new Crypto(investmentNames[generate.Next(investmentNames.Length)]));
                }
                else if (classType == "DividendStock")
                {
                    Investments.Add(new DividendStock(investmentNames[generate.Next(investmentNames.Length)]));
                }
                else if (classType == "ETF")
                {
                    Investments.Add(new ETF(investmentNames[generate.Next(investmentNames.Length)]));
                }
                else
                {
                    Investments.Add(new Stock(investmentNames[generate.Next(investmentNames.Length)]));
                }

            }


            InitializeComponent(); //This sets up the Form1 display found in Form1.Designer.cs
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //This is the start button, it initializes all textboxes with names and values
            button17.Visible = false;
            textBox1.Text = $"{Investments[0].GetName()}";
            textBox3.Text = $"{Investments[1].GetName()}";
            textBox5.Text = $"{Investments[2].GetName()}";
            textBox7.Text = $"{Investments[3].GetName()}";
            textBox9.Text = $"{Investments[4].GetName()}";
            textBox11.Text = $"{Investments[5].GetName()}";
            textBox13.Text = $"{Investments[6].GetName()}";
            textBox15.Text = $"{Investments[7].GetName()}";
            textBox17.Text = $"{Investments[8].GetName()}";
            toolTip1.SetToolTip(textBox1, $"{Investments[0].GetDescription()}");
            toolTip3.SetToolTip(textBox3, $"{Investments[1].GetDescription()}");
            toolTip4.SetToolTip(textBox5, $"{Investments[2].GetDescription()}");
            toolTip5.SetToolTip(textBox7, $"{Investments[3].GetDescription()}");
            toolTip6.SetToolTip(textBox9, $"{Investments[4].GetDescription()}");
            toolTip7.SetToolTip(textBox11, $"{Investments[5].GetDescription()}");
            toolTip8.SetToolTip(textBox13, $"{Investments[6].GetDescription()}");
            toolTip9.SetToolTip(textBox15, $"{Investments[7].GetDescription()}");
            toolTip10.SetToolTip(textBox17, $"{Investments[8].GetDescription()}");
            toolTip11.SetToolTip(textBox24, $"These are upcoming events, they usually happen but sometimes there is chance that they wont");
            textBox2.Text = $"${Math.Round(Investments[0].GetValue(), 3)}";
            textBox4.Text = $"${Math.Round(Investments[1].GetValue(), 3)}";
            textBox6.Text = $"${Math.Round(Investments[2].GetValue(), 3)}";
            textBox8.Text = $"${Math.Round(Investments[3].GetValue(), 3)}";
            textBox10.Text = $"${Math.Round(Investments[4].GetValue(), 3)}";
            textBox12.Text = $"${Math.Round(Investments[5].GetValue(), 3)}";
            textBox14.Text = $"${Math.Round(Investments[6].GetValue(), 3)}";
            textBox16.Text = $"${Math.Round(Investments[7].GetValue(), 3)}";
            textBox18.Text = $"${Math.Round(Investments[8].GetValue(), 3)}";
            textBox21.Text = $"${Math.Round(money, 3)}";
            textBox23.Text = $"Week: {gameTime}";
            //Set all Text boxes to read only
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox17.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox19.ReadOnly = true;
            textBox20.ReadOnly = true;
            textBox21.ReadOnly = true;
            textBox22.ReadOnly = true;
            textBox23.ReadOnly = true;
            textBox24.ReadOnly = true;
            if (Events.Count > 0)
            {
                //This will update the warning box, ulitmately just showing no upcoming events but the same block of code is used later in the program
                if (Events[Events.Count - 1].GetWarning())
                {
                    if (Events[Events.Count - 1].GetGlobal())
                    {
                        textBox24.Text = $"Upcoming Events: {Events[Events.Count - 1].GetName()} will affect whole stock market";
                    }
                    else
                    {
                        textBox24.Text = $"Upcoming Events: {Events[Events.Count - 1].GetName()} will affect {Investments[Events[Events.Count - 1].GetCompanyImpacted()].GetName()}";
                    }
                } 
                else
                {
                    textBox24.Text = $"Upcoming Events: None";
                }
            }
            else
            {
                textBox24.Text = $"Upcoming Events: None";
            }
        }

        //These are our select buttons, they 'select' the investment we are focusing on, in so doing they update the name and number of stocks text boxes
        private void button7_Click(object sender, EventArgs e)
        {
            currentSelect = 0;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentSelect = 1;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentSelect = 2;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            currentSelect = 3;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }
        private void button11_Click(object sender, EventArgs e)
        {
            currentSelect = 4;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            currentSelect = 5;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            currentSelect = 6;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            currentSelect = 7;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            currentSelect = 8;
            textBox20.Text = $"{Investments[currentSelect].GetName()}";
            textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
        }

        //The Buy buttons, They also update the values of the Money textbox and number of stocks textbox
        private void button1_Click(object sender, EventArgs e)
        {
            if (money >= Investments[currentSelect].GetValue())
            {
                Investments[currentSelect].SetNumberOfStocks(Investments[currentSelect].GetNumberOfStocks() + 1);
                money -= Investments[currentSelect].GetValue();
                textBox21.Text = $"${Math.Round(money, 3)}";
                textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (money >= Investments[currentSelect].GetValue() * 10)
            {
                Investments[currentSelect].SetNumberOfStocks(Investments[currentSelect].GetNumberOfStocks() + 10);
                money -= Investments[currentSelect].GetValue() * 10;
                textBox21.Text = $"${Math.Round(money, 3)}";
                textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (money >= Investments[currentSelect].GetValue() * 100)
            {
                Investments[currentSelect].SetNumberOfStocks(Investments[currentSelect].GetNumberOfStocks() + 100);
                money -= Investments[currentSelect].GetValue() * 100;
                textBox21.Text = $"${Math.Round(money, 3)}";
                textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
            }
        }

        //The Sell buttons, They also update the values of the Money textbox and number of stocks textbox
        private void button4_Click(object sender, EventArgs e)
        {
            if (Investments[currentSelect].GetNumberOfStocks() > 0)
            {
                Investments[currentSelect].SetNumberOfStocks(Investments[currentSelect].GetNumberOfStocks() - 1);
                money += Investments[currentSelect].GetValue();
                textBox21.Text = $"${Math.Round(money, 3)}";
                textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Investments[currentSelect].GetNumberOfStocks() > 9)
            {
                Investments[currentSelect].SetNumberOfStocks(Investments[currentSelect].GetNumberOfStocks() - 10);
                money += Investments[currentSelect].GetValue() * 10;
                textBox21.Text = $"${Math.Round(money, 3)}";
                textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Investments[currentSelect].GetNumberOfStocks() > 99)
            {
                Investments[currentSelect].SetNumberOfStocks(Investments[currentSelect].GetNumberOfStocks() - 100);
                money += Investments[currentSelect].GetValue() * 100;
                textBox21.Text = $"${Math.Round(money, 3)}";
                textBox22.Text = $"# Stocks: {Investments[currentSelect].GetNumberOfStocks()}";
            }
        }

        //The Next Week button, the game upadtes it's values and posts a possible upcoming event.
        private void button16_Click(object sender, EventArgs e)
        {
            gameTime += 1; //Increase the game time by 1 week
            textBox23.Text = $"Week: {gameTime}"; //Display gametime to Week box
            foreach (Investment investment in Investments)
            {
                //Set previous values to compare to, this will help the user see what investments are growing/shrinking
                investment.SetPreviousValue(investment.GetValue());
            }
            if (Events.Count > 0)
            {
                //Calculate the impact of an event based on it's chance of happening
                if (generate.Next(100) < Events[Events.Count - 1].GetCertainty())
                {
                    if (Events[Events.Count - 1].GetGlobal())
                    {
                        foreach (Investment investment in Investments)
                        {
                            investment.CalculateImpact(Events[Events.Count - 1].GetImpact(), Events[Events.Count - 1].GetGrowth());
                        }
                    }
                    else
                    {
                        Investments[Events[Events.Count - 1].GetCompanyImpacted()].CalculateImpact(Events[Events.Count - 1].GetImpact(), Events[Events.Count - 1].GetGrowth());
                    }
                }
            }
            //Calculate the growth of each Investment and returns for DividendStocks
            foreach (Investment investment in Investments)
            {
                investment.CalculateGrowth();
                if (investment is DividendStock)
                {
                    money += ((DividendStock)investment).DividendPayout(gameTime);
                }
            }
            //Update the shown values of the investments
            textBox2.Text = $"${Math.Round(Investments[0].GetValue(), 3)}";
            textBox4.Text = $"${Math.Round(Investments[1].GetValue(), 3)}";
            textBox6.Text = $"${Math.Round(Investments[2].GetValue(), 3)}";
            textBox8.Text = $"${Math.Round(Investments[3].GetValue(), 3)}";
            textBox10.Text = $"${Math.Round(Investments[4].GetValue(), 3)}";
            textBox12.Text = $"${Math.Round(Investments[5].GetValue(), 3)}";
            textBox14.Text = $"${Math.Round(Investments[6].GetValue(), 3)}";
            textBox16.Text = $"${Math.Round(Investments[7].GetValue(), 3)}";
            textBox18.Text = $"${Math.Round(Investments[8].GetValue(), 3)}";
            //Update the growth symbol next to each investment, I'm not sure how to do this more efficiently so this is a lot of code
            //First 3 labels
            if (Investments[0].GetPreviousValue() < Investments[0].GetValue())
            {
                label1.Text = "▲";
                label1.ForeColor = Color.Green;
            }
            else if (Investments[0].GetPreviousValue() > Investments[0].GetValue())
            {
                label1.Text = "▼";
                label1.ForeColor = Color.Red;
            }
            if (Investments[1].GetPreviousValue() < Investments[1].GetValue())
            {
                label2.Text = "▲";
                label2.ForeColor = Color.Green;
            }
            else if (Investments[1].GetPreviousValue() > Investments[1].GetValue())
            {
                label2.Text = "▼";
                label2.ForeColor = Color.Red;
            }
            if (Investments[2].GetPreviousValue() < Investments[2].GetValue())
            {
                label3.Text = "▲";
                label3.ForeColor = Color.Green;
            }
            else if (Investments[2].GetPreviousValue() > Investments[2].GetValue())
            {
                label3.Text = "▼";
                label3.ForeColor = Color.Red;
            }
            //Second 3 labels
            if (Investments[3].GetPreviousValue() < Investments[3].GetValue())
            {
                label4.Text = "▲";
                label4.ForeColor = Color.Green;
            }
            else if (Investments[3].GetPreviousValue() > Investments[3].GetValue())
            {
                label4.Text = "▼";
                label4.ForeColor = Color.Red;
            }
            if (Investments[4].GetPreviousValue() < Investments[4].GetValue())
            {
                label5.Text = "▲";
                label5.ForeColor = Color.Green;
            }
            else if (Investments[4].GetPreviousValue() > Investments[4].GetValue())
            {
                label5.Text = "▼";
                label5.ForeColor = Color.Red;
            }
            if (Investments[5].GetPreviousValue() < Investments[5].GetValue())
            {
                label6.Text = "▲";
                label6.ForeColor = Color.Green;
            }
            else if (Investments[5].GetPreviousValue() > Investments[5].GetValue())
            {
                label6.Text = "▼";
                label6.ForeColor = Color.Red;
            }
            //Finally 3 labels
            if (Investments[6].GetPreviousValue() < Investments[6].GetValue())
            {
                label7.Text = "▲";
                label7.ForeColor = Color.Green;
            }
            else if (Investments[6].GetPreviousValue() > Investments[6].GetValue())
            {
                label7.Text = "▼";
                label7.ForeColor = Color.Red;
            }
            if (Investments[7].GetPreviousValue() < Investments[7].GetValue())
            {
                label8.Text = "▲";
                label8.ForeColor = Color.Green;
            }
            else if (Investments[7].GetPreviousValue() > Investments[7].GetValue())
            {
                label8.Text = "▼";
                label8.ForeColor = Color.Red;
            }
            if (Investments[8].GetPreviousValue() < Investments[8].GetValue())
            {
                label9.Text = "▲";
                label9.ForeColor = Color.Green;
            }
            else if (Investments[8].GetPreviousValue() > Investments[8].GetValue())
            {
                label9.Text = "▼";
                label9.ForeColor = Color.Red;
            }

            //Create a new event
            if (generate.Next(2) == 1)
            {
                Events.Add(new Event(GoodEventNames[generate.Next(GoodEventNames.Length)], true));
            }
            else
            {
                Events.Add(new Event(BadEventNames[generate.Next(BadEventNames.Length)], false));
            }
            //Update the warning box to show the new event if there is warning
            if (Events.Count > 0)
            {
                if (Events[Events.Count - 1].GetGlobal())
                {
                    textBox24.Text = $"Upcoming Events: {Events[Events.Count - 1].GetName()} will affect whole stock market";
                }
                else
                {
                    textBox24.Text = $"Upcoming Events: {Events[Events.Count - 1].GetName()} will affect {Investments[Events[Events.Count - 1].GetCompanyImpacted()].GetName()}";
                }
            }
            else
            {
                textBox24.Text = $"Upcoming Events: None";
            }

        }
    }
}
