using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Services.Interfaces;

namespace UniClub.Services
{
    public class FirebaseUploadService : IUploadService
    {
        
        private static string API_KEY = "AIzaSyB3r14X6dC4QYGvrYN7hVrLgNZNliK9ruQ";
        private static string BUCKET = "premium-client-337312.appspot.com";
        private static string AUTH_EMAIL = "administrator@uniclub.com";
        private static string AUTH_PASSWORD = "~d[3f6mz)yxx'D=y";
        public async Task<string> Upload(IFormFile file, string folder = "files")
        {
            string link = string.Empty;
            try
            {
                using (var stream = file.OpenReadStream())
                {
                    
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
                    var signIn = await auth.SignInWithEmailAndPasswordAsync(AUTH_EMAIL, AUTH_PASSWORD);

                    var cancellation = new CancellationTokenSource();

                    var task = new FirebaseStorage(
                        BUCKET,
                        new FirebaseStorageOptions
                        {

                            AuthTokenAsyncFactory = () => Task.FromResult(signIn.FirebaseToken),
                            ThrowOnCancel = true
                        })
                        .Child(folder)
                        .Child(Path.GetRandomFileName() + Path.GetExtension(file.FileName))
                        .PutAsync(stream);
                    link = await task;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return link;
        }
    }
}
