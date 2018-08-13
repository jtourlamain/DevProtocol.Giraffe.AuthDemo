module DevProtocol.Giraffe.AuthDemo.Web.Routing

open Giraffe
open DevProtocol.Giraffe.AuthDemo.Web.HttpHandlers


let authorize = 
    requiresAuthentication(challenge "OpenIdConnect")

let routes: HttpFunc -> HttpFunc =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "test"
                route "/secure" >=> authorize >=> handleGetSecure
            ]
        setStatusCode 404 >=> text "Not Found" ]