﻿using SE_Coursework.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SE_Coursework.Pages
{
    /// <summary>
    /// Interaction logic for ViewMessagesPage.xaml
    /// </summary>
    public partial class ViewMessagesPage : Page        
    {
        ValidationClass validation = new ValidationClass();
        JsonClass json = new JsonClass();

        List<MessageClass> listOfMessages = new List<MessageClass>();

        int displayCounter = 0;       

        public ViewMessagesPage()
        {
            InitializeComponent();
            RetrieveStoredList();
            DisplayInitialMessage();
            
        }


        #region Click Events

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayNextMessage();            
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayPreviousMessage();
        }

        #endregion


        #region Navigation Buttons

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Instantiate an object of the InputManually page
            MenuPage menuPage = new MenuPage();

            // Navigates to the InputManually page
            NavigationService.Navigate(menuPage);
        }

        // Method which handles the 'Exit Application' button being clicked
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {


            // Calls the method ExitApplicationValidation() from the Validation class.
            validation.ExitApplicationValidation();
        }

        #endregion


        #region Private Methods
        
        private void DisplayInitialMessage()
        {
            if (displayCounter < (listOfMessages.Count - 1))
            {    
                messageHeaderTxt.Text = listOfMessages[displayCounter].Header;
                messageSenderTxt.Text = listOfMessages[displayCounter].Sender;
                messageSubjectTxt.Text = listOfMessages[displayCounter].Subject;
                messageBodyTxt.Text = listOfMessages[displayCounter].MessageText;

            }
            else
            {
                MessageBox.Show("There are no more messages in the list to view.");
            }

        }


        private void DisplayNextMessage()
        {
            if (displayCounter < (listOfMessages.Count - 1))
            {
                displayCounter = displayCounter + 1;

                messageHeaderTxt.Text = listOfMessages[displayCounter].Header;
                messageSenderTxt.Text = listOfMessages[displayCounter].Sender;
                messageSubjectTxt.Text = listOfMessages[displayCounter].Subject;
                messageBodyTxt.Text = listOfMessages[displayCounter].MessageText;

            }
            else
            {
                MessageBox.Show("There are no more messages in the list to view.");
            }
        }

        private void DisplayPreviousMessage()
        {            
            if (displayCounter > 0)
            {
                displayCounter = displayCounter - 1;

                messageHeaderTxt.Text = listOfMessages[displayCounter].Header;
                messageSenderTxt.Text = listOfMessages[displayCounter].Sender;
                messageSubjectTxt.Text = listOfMessages[displayCounter].Subject;
                messageBodyTxt.Text = listOfMessages[displayCounter].MessageText;

            }
            else
            {
                MessageBox.Show("You are at the start of the list.");
            }            
        }


        public void RetrieveStoredList()
        {
            int counter = 0;

            try
            {
                // Returns the list that is stored as JSON             
                listOfMessages = json.Deserialize();

                counter = counter + 1;


                
            }
            catch (Exception ex)
            {
                if (counter > 0)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        #endregion

       
    }
}
