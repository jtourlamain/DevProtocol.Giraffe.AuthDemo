module DevProtocol.Giraffe.AuthDemo.Web.HttpHandlers

open Giraffe
open DevProtocol.Giraffe.AuthDemo.Web.Models
open Giraffe.Razor
open Microsoft.AspNetCore.Http


let indexHandler (name : string) =
    fun (next : HttpFunc) (ctx: HttpContext) ->
        let greetings = sprintf "Hello %s" name
        let model     = { Text = greetings }
        razorHtmlView "Index" model next ctx

let handleGetSecure =
    fun (next : HttpFunc) (ctx: HttpContext) ->
        let model = {Text = "yes"}
        razorHtmlView "Secure" model next ctx