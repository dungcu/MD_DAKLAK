using MDSolutionEntities;
using MDSolution;
namespace DACASUCO.Properties

{
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        
        public Settings() {            
            this["MDSolutionConnectionString"] =  "Data Source=" + MDSolutionEntities.DBModule.ServerName + ";Initial Catalog=" + MDSolutionEntities.DBModule.DatabaseName + ";Persist Security Info=True;User ID=" + MDSolutionEntities.DBModule.UserID + ";Password=" + MDSolutionEntities.DBModule.Password;
            this["MD08ConnectionString"] = "Data Source=" + MDSolutionEntities.DBModule.ServerName + ";Initial Catalog=" + MDSolutionEntities.DBModule.DatabaseName + ";Persist Security Info=True;User ID=" + MDSolutionEntities.DBModule.UserID + ";Password=" + MDSolutionEntities.DBModule.Password;
            this["MDSolution_HĐĐT"] ="Data Source=" + MDSolutionEntities.DBModule.ServerName + ";Initial Catalog=" + MDSolutionEntities.DBModule.DatabaseName + ";Persist Security Info=True;User ID=" + MDSolutionEntities.DBModule.UserID + ";Password=" + MDSolutionEntities.DBModule.Password;                       
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }

       
    }
}
