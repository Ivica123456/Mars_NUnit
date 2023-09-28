using AdvancedTask_NUnit.DataModel;
using AdvancedTask_NUnit.Utilities;
using Newtonsoft.Json;






namespace AdvancedTask_NUnit.Tests
{
    public class UserDetailsTests : CommonDriver
    {
       
       

        [Test, Order(1), Description("Change availability to Full Time")]
        public void AvailabilityUpdate()
        {
            // Log the test step in the Extent Report
            test.Info("Starting Availability Test...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\ProfilePage_user_details.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            ProfilePage_DataModel profilePage_DataModel = JsonConvert.DeserializeObject<ProfilePage_DataModel>(jsonContent);

            // Access the values from the DataModel object
            string availability = profilePage_DataModel.availability;

            userDetailsPageObj.availabilityAdd(profilePage_DataModel);

            // Assert that the updated availability matches the expected value
            Assert.That(userDetailsPageObj.actaulAvailability(), Is.EqualTo(availability), "Education should match the expected value.");
            test.Pass("Availability value verified.");
        }
       
        [Test, Order(2), Description("Update the hours to as needed a week")]
        public void hoursUpdate()
        {
            // Log the test step in the Extent Report
            test.Info("Starting Hours Test...");

            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\ProfilePage_user_details.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            ProfilePage_DataModel profilePage_DataModel = JsonConvert.DeserializeObject<ProfilePage_DataModel>(jsonContent);

            // Access the values from the DataModel object
            string hours = profilePage_DataModel.hours;

            userDetailsPageObj.hoursUpdateAdd(profilePage_DataModel);

            // Assert that the updated hours matches the expected value
            Assert.That(userDetailsPageObj.actaulhoursUpdate(), Is.EqualTo(hours), "Education should match the expected value.");
            test.Pass("Hours value verified.");

        }
        [Test, Order(3), Description("Change your earn target to $1000 per month")]
        public void earnTargetUpdate()
        {
            // Log the test step in the Extent Report
            test.Info("Starting Earn target Test...");


            // Read the JSON file
            string jsonFilePath = "C:\\Users\\Ivica\\Desktop\\AdvancedTask-NUnit\\AdvancedTask_NUnit\\AdvancedTask_NUnit\\JsonData\\ProfilePage_user_details.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into the RegisterModel object
            ProfilePage_DataModel profilePage_DataModel = JsonConvert.DeserializeObject<ProfilePage_DataModel>(jsonContent);

            // Access the values from the DataModel object
            string earnTarget = profilePage_DataModel.earnTarget;


            userDetailsPageObj.earnTargetUpdate(profilePage_DataModel);

            // Assert that the updated hours matches the expected value
            Assert.That(userDetailsPageObj.actualEarnTarget(), Is.EqualTo(earnTarget), "Education should match the expected value.");
            test.Pass("Earn target value verified.");
        }
       



    }
}