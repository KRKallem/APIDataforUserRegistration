using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using APIDataforUserRegistration.Models;


namespace APIDataforUserRegistration.Controllers
{
    public class UserRegistrationController : ApiController
    {
        WebAPIDBAccess ServiceDB = new WebAPIDBAccess();
        public UserRegistrationController()

        {
            entity = new WebAPIDBAccess();
        }

        protected WebAPIDBAccess entity { get; set; }

        [HttpGet]
        [Route("api/UserRegistration/GetUserInfo")]
        public async Task<List<object>> GetUserInfo()
        {
            using (entity)
            {
                entity.Configuration.ProxyCreationEnabled = false;
                var userlist = await (from userdata in entity.UserInfoes
                                      select new
                                      {
                                          Id = userdata.ID,
                                          Username = userdata.UserName,
                                          Email = userdata.Email,
                                          PhoneNumber = userdata.PhoneNumber,
                                          Skillset = userdata.Skillset,
                                          Hobby = userdata.Hobby,
                                      }).ToListAsync<object>();
                return userlist;
            }
        }

        [HttpPost]
        [Route("api/UserRegistration/SaveUserData")]
        public Task<HttpResponseMessage> SaveUserData(UserInfo userdata)
        {
            using (ServiceDB)
            {
                try
                {
                    if (userdata.ID == 0)
                    {
                        ServiceDB.UserInfoes.Add(userdata);
                        ServiceDB.SaveChanges();
                    }
                    else
                    {
                        var type = ServiceDB.UserInfoes.Where(x => x.ID == userdata.ID).FirstOrDefault();
                        if (type != null)
                        {
                            type.UserName = userdata.UserName;
                            type.Email = userdata.Email;
                            type.PhoneNumber = userdata.PhoneNumber;
                            type.Skillset = userdata.Skillset;
                            type.Hobby = userdata.Hobby;
                            ServiceDB.SaveChanges();
                        }
                        else
                        {
                           // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Data not found");
                        }
                    }
                    return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, true));
                }
                catch (Exception Ex)
                {
                    return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, "Operation Failed Something Went Wrong :" + Ex.Message));
                }
            }
        }

        [HttpGet]
        [Route("api/UserRegistration/EditUserInfobyList")]
        public async Task<HttpResponseMessage> EditUserInfobyList(int ID)
        {
            try
            {
                using (entity)
                {
                    var UserInfo = await (from V in entity.UserInfoes                                              
                                              where V.ID == ID
                                              select new
                                              {
                                                  ID = V.ID,
                                                  Username = V.UserName,
                                                  Email = V.Email,
                                                  PhoneNumber = V.PhoneNumber,
                                                  Skillset = V.Skillset,
                                                  Hobby = V.Hobby
                                              }).FirstOrDefaultAsync();
                    return Request.CreateResponse(HttpStatusCode.OK, UserInfo);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Internel Server Error");
            }
        }





        [HttpGet]
        [Route("api/UserRegistration/Deleteuser")]
        public async Task<HttpResponseMessage> Deleteuser(int ID)
        {
            try
            {
                using (ServiceDB)
                {
                    ServiceDB.Configuration.ProxyCreationEnabled = false;
                    ServiceDB.Configuration.ProxyCreationEnabled = false;
                    var Entity = ServiceDB.UserInfoes.Where(x => x.ID == ID).FirstOrDefault();
                    if (Entity != null)
                    {
                        ServiceDB.UserInfoes.Remove(Entity);
                        ServiceDB.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, true);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, false);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, false);
            }
        }



        [HttpPut]
        [Route("api/UserRegistration/UpdateUserData")]
        public Task<HttpResponseMessage> UpdateUserData(UserInfo userdata)
        {
            using (ServiceDB)
            {
                try
                {
                    var type = ServiceDB.UserInfoes.Where(x => x.ID == userdata.ID).FirstOrDefault();
                    if (type != null)
                    {
                        type.UserName = userdata.UserName;
                        type.Email = userdata.Email;
                        type.PhoneNumber = userdata.PhoneNumber;
                        type.Skillset = userdata.Skillset;
                        type.Hobby = userdata.Hobby;
                        ServiceDB.SaveChanges();
                        
                    }
                    else
                    {
                       // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "user with Id " +  + " not found to update");
                    }
                    return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, true));
                }
                catch (Exception Ex)
                {
                    return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, "Operation Failed Something Went Wrong :" + Ex.Message));
                }
            }
        }
    }
}
