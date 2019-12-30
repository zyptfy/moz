﻿using System;
using Moz.Bus.Models.Members;
using Moz.CMS.Models.Members;
using Moz.WebApi;

namespace Moz.Auth
{
    public interface IAuthService
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SimpleMember GetAuthenticatedMember();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetAuthenticatedUId();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="roleId"></param>
        /// <param name="expDatetime"></param>
        /// <returns>true 成功, false 失败</returns>
        bool AddRoleToMemberId(long memberId, long roleId, DateTime? expDatetime = null);


        /// <summary>
        /// 用户名密码登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MemberLoginResult LoginWithUsernamePassword(MemberLoginRequest request);

        /// <summary>
        /// 三方授权登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MemberLoginResult ExternalAuth(ExternalAuthRequest request);


        void SetAuthCookie(string token);


        void RemoveAuthCookie();

    }
}