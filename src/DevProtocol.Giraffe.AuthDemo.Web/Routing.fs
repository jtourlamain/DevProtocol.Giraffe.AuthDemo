module DevProtocol.Giraffe.AuthDemo.Web.Routing

open Giraffe
open DevProtocol.Giraffe.AuthDemo.Web.HttpHandlers
open Microsoft.AspNetCore.Authentication.OpenIdConnect


let authorize = 
    requiresAuthentication(challenge OpenIdConnectDefaults.AuthenticationScheme)

let routes: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "test"
                route "/secure" >=> authorize >=> handleGetSecure
            ]
        setStatusCode 404 >=> text "Not Found" ]