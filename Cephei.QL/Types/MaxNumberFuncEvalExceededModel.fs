﻿(*
Copyright (C) 2020 Cepheis Ltd (steve.channell@cepheis.com)

This file is part of Cephei.QL Project https://github.com/channell/Cephei

Cephei.QL is open source software based on QLNet  you can redistribute it and/or modify it
under the terms of the Cephei.QL license.  You should have received a
copy of the license along with this program; if not, license is
available at <https://github.com/channell/Cephei/LICENSE>.

QLNet is a based on QuantLib, a free-software/open-source library
for financial quantitative analysts and developers - http://quantlib.org/
The QuantLib license is available online at http://quantlib.org/license.shtml.

This program is distributed in the hope that it will be useful, but WITHOUT
ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
FOR A PARTICULAR PURPOSE.  See the license for more details.
*)
namespace Cephei.QL

open System
open Cephei.QL.Util
open Cephei.Cell
open Cephei.Cell.Generic
open System.Collections
open System.Collections.Generic
open QLNet
open Cephei.QLNetHelper

(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type MaxNumberFuncEvalExceededModel
    ( message                                      : ICell<string>
    , inner                                        : ICell<Exception>
    ) as this =

    inherit Model<MaxNumberFuncEvalExceeded> ()
(*
    Parameters
*)
    let _message                                   = message
    let _inner                                     = inner
(*
    Functions
*)
    let mutable
        _MaxNumberFuncEvalExceeded                 = cell (fun () -> new MaxNumberFuncEvalExceeded (message.Value, inner.Value))
    do this.Bind(_MaxNumberFuncEvalExceeded)
(* 
    casting 
*)
    internal new () = new MaxNumberFuncEvalExceededModel(null,null)
    member internal this.Inject v = _MaxNumberFuncEvalExceeded <- v
    static member Cast (p : ICell<MaxNumberFuncEvalExceeded>) = 
        if p :? MaxNumberFuncEvalExceededModel then 
            p :?> MaxNumberFuncEvalExceededModel
        else
            let o = new MaxNumberFuncEvalExceededModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.message                            = _message 
    member this.inner                              = _inner 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type MaxNumberFuncEvalExceededModel1
    ( message                                      : ICell<string>
    ) as this =

    inherit Model<MaxNumberFuncEvalExceeded> ()
(*
    Parameters
*)
    let _message                                   = message
(*
    Functions
*)
    let mutable
        _MaxNumberFuncEvalExceeded                 = cell (fun () -> new MaxNumberFuncEvalExceeded (message.Value))
    do this.Bind(_MaxNumberFuncEvalExceeded)
(* 
    casting 
*)
    internal new () = new MaxNumberFuncEvalExceededModel1(null)
    member internal this.Inject v = _MaxNumberFuncEvalExceeded <- v
    static member Cast (p : ICell<MaxNumberFuncEvalExceeded>) = 
        if p :? MaxNumberFuncEvalExceededModel1 then 
            p :?> MaxNumberFuncEvalExceededModel1
        else
            let o = new MaxNumberFuncEvalExceededModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.message                            = _message 
(* <summary>


  </summary> *)
[<AutoSerializable(true)>]
type MaxNumberFuncEvalExceededModel2
    () as this =
    inherit Model<MaxNumberFuncEvalExceeded> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _MaxNumberFuncEvalExceeded                 = cell (fun () -> new MaxNumberFuncEvalExceeded ())
    do this.Bind(_MaxNumberFuncEvalExceeded)
(* 
    casting 
*)
    
    member internal this.Inject v = _MaxNumberFuncEvalExceeded <- v
    static member Cast (p : ICell<MaxNumberFuncEvalExceeded>) = 
        if p :? MaxNumberFuncEvalExceededModel2 then 
            p :?> MaxNumberFuncEvalExceededModel2
        else
            let o = new MaxNumberFuncEvalExceededModel2 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
