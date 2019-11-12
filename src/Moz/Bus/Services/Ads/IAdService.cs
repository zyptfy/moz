﻿using System;
using System.Linq;
using Moz.Biz.Dtos.AdPlaces;
using Moz.Biz.Dtos.Ads;

namespace Moz.Biz.Services.Ads
{
    public interface IAdService
    {
        #region 广告位置
        
        CreateAdPlaceResponse CreateAdPlace(CreateAdPlaceRequest request);
        UpdateAdPlaceResponse UpdateAdPlace(UpdateAdPlaceRequest request);
        DeleteAdPlaceResponse DeleteAdPlace(DeleteAdPlaceRequest request);
        BulkDeleteAdPlacesResponse BulkDeleteAdPlaces(BulkDeleteAdPlacesRequest request);
        GetAdPlaceDetailResponse GetAdPlaceDetail(GetAdPlaceDetailRequest request);
        PagedQueryAdPlaceResponse PagedQueryAdPlaces(PagedQueryAdPlaceRequest request);
        
        #endregion
        
        #region 广告

        CreateAdResponse CreateAd(CreateAdRequest request);
        UpdateAdResponse UpdateAd(UpdateAdRequest request);
        DeleteAdResponse DeleteAd(DeleteAdRequest request);
        BulkDeleteAdsResponse BulkDeleteAds(BulkDeleteAdsRequest request);
        GetAdDetailResponse GetAdDetail(GetAdDetailRequest request);
        PagedQueryAdResponse PagedQueryAds(PagedQueryAdRequest request);

        SetAdOrderResponse SetAdOrder(SetAdOrderRequest request);

        SetAdIsShowResponse SetAdIsShow(SetAdIsShowRequest request);

        GetAdsByCodeResponse GetAdsByCode(GetAdsByCodeRequest request);

        #endregion
    }
}