using System;
using System.Threading.Tasks;
using apiAng.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace apiAng.Api.Data {
    public class AtuthRepisitory : IAuthRepository

    {
        private readonly DataApiContext _context;

        public AtuthRepisitory (DataApiContext context) {
            this._context = context;

        }
        public  async Task<User> Login (string UserName, string password) {
        var user= await _context.Users.FirstOrDefaultAsync( x=>x.Name == UserName);
if(user==null)
    return null;

if(!VeriFyPassword(password, user.PasswodHash, user.PasswordSalt)){
       return null;
}

        }


        public async Task<User> Register (User user, string password) {
            byte[] PasswordHash, passwodSoald;
            CreatPasswordHash (password, out PasswordHash, out passwodSoald);
            user.PasswodHash = PasswordHash;
            user.PasswordSalt = passwodSoald;
         await _context.Users.AddAsync(user);
await _context.SaveChangesAsync();

return user;

        }

        public async Task<bool> UserExsit (string UserName) {
  if(await _context.Users.AnyAsync(m=>m.Name==UserName)){
      return true;
  }
  return false;
        }

        public void CreatPasswordHash (string password, out byte[] CreatPasswordHash, out byte[] passwordSold) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {

                passwordSold = hmac.Key;
                CreatPasswordHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
            }
        }
        
        private bool VeriFyPassword(string password, byte[] passwodHash, byte[] passwordSalt)
        {
              using (var hmac = new System.Security.Cryptography.HMACSHA512 (passwordSalt)) {

             
             var ComputeHash    = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (password));
             for(int i=0;i <ComputeHash.Length;i++){
                  if(ComputeHash[i]!=passwodHash[i])return false;

             }
             return true;
            }
        }
    }
}