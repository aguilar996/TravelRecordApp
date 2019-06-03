#define OFFLINE_SYNC_ENABLED

using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecordApp.Helpers
{
    public class AzureAppServiceHelper
    {
        //Push to the cloud method, or update if cloud avilable
        //Evaluamos si no hay internet o no se syncheó

        public static async Task SyncAsync()
        {
             
        ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await App.MobileService.SyncContext.PushAsync();
                await App.postsTable.PullAsync("userPost", "");
            }
            //Catch de push failure
            catch (MobileServicePushFailedException mspfe)
            {
                if(mspfe.PushResult!=null)
                {//Si hay errores lo asignamos a la variable
                    syncErrors = mspfe.PushResult.Errors;
                }
            }
            catch (Exception E)
            {

            }
            if(syncErrors!=null)
            {
                foreach(var error in syncErrors)
                {
                    if(error.OperationKind == MobileServiceTableOperationKind.Update &&
                        error.Result!=null)
                    {
                        await error.CancelAndUpdateItemAsync(error.Result); ;
                    }
                    else
                    {
                        await error.CancelAndDiscardItemAsync();
                    }
                }
            }
        }
    }
}
