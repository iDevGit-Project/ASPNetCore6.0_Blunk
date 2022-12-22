//using Data.Repositories;
//using Entities;
//using Entities.Constants;
//using Entities.TeacherInfo;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WebFramework.Filters
//{
//    public class TeacherMvcOnActionExecutingFilterAttribute : ActionFilterAttribute
//    {
//        public readonly IRepository<TeacherProfileDescription> _repoTeacherProfileDescription;
//        public readonly UserManager<User> userManager;

//        public TeacherMvcOnActionExecutingFilterAttribute(IRepository<TeacherProfileDescription> repoTeacherProfileDescription, UserManager<User> userManager)
//        {
//            _repoTeacherProfileDescription = repoTeacherProfileDescription;
//            this.userManager = userManager;
//        }
//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            if (context.HttpContext.User.IsInRole("Teacher"))
//            {
//                var findUser = userManager.FindByNameAsync(context.HttpContext.User.Identity.Name).Result;

//                var checkStatus = _repoTeacherProfileDescription.TableNoTracking.FirstOrDefault(x => x.TeacherUserId == findUser.Id);
//                if (checkStatus != null)
//                {
//                    if(checkStatus.TeacherStatus != TeacherStatuses.AllGood)
//                    {
//                        //just an example for more use cases

//                        if(checkStatus.TeacherStatus == TeacherStatuses.BaseFolan)
//                        {
//                            context.Result = new RedirectToRouteResult("/Profile/About");
//                        }
//                    }
//                }
//            }

//            base.OnActionExecuting(context);
//        }
//    }
//}
