(*
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
  A Bermudan option can only be exercised at a set of fixed dates.

  </summary> *)
[<AutoSerializable(true)>]
type BermudanExerciseModel
    ( dates                                        : ICell<Generic.List<Date>>
    ) as this =

    inherit Model<BermudanExercise> ()
(*
    Parameters
*)
    let _dates                                     = dates
(*
    Functions
*)
    let _BermudanExercise                          = cell (fun () -> new BermudanExercise (dates.Value))
    let _payoffAtExpiry                            = cell (fun () -> _BermudanExercise.Value.payoffAtExpiry())
    let _date                                      (index : ICell<int>)   
                                                   = cell (fun () -> _BermudanExercise.Value.date(index.Value))
    let _dates                                     = cell (fun () -> _BermudanExercise.Value.dates())
    let _lastDate                                  = cell (fun () -> _BermudanExercise.Value.lastDate())
    let _type                                      = cell (fun () -> _BermudanExercise.Value.TYPE())
    do this.Bind(_BermudanExercise)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.PayoffAtExpiry                     = _payoffAtExpiry
    member this.Date                               index   
                                                   = _date index 
    member this.Dates                              = _dates
    member this.LastDate                           = _lastDate
    member this.Type                               = _type
(* <summary>
  A Bermudan option can only be exercised at a set of fixed dates.

  </summary> *)
[<AutoSerializable(true)>]
type BermudanExerciseModel1
    ( dates                                        : ICell<Generic.List<Date>>
    , payoffAtExpiry                               : ICell<bool>
    ) as this =

    inherit Model<BermudanExercise> ()
(*
    Parameters
*)
    let _dates                                     = dates
    let _payoffAtExpiry                            = payoffAtExpiry
(*
    Functions
*)
    let _BermudanExercise                          = cell (fun () -> new BermudanExercise (dates.Value, payoffAtExpiry.Value))
    let _payoffAtExpiry                            = cell (fun () -> _BermudanExercise.Value.payoffAtExpiry())
    let _date                                      (index : ICell<int>)   
                                                   = cell (fun () -> _BermudanExercise.Value.date(index.Value))
    let _dates                                     = cell (fun () -> _BermudanExercise.Value.dates())
    let _lastDate                                  = cell (fun () -> _BermudanExercise.Value.lastDate())
    let _type                                      = cell (fun () -> _BermudanExercise.Value.TYPE())
    do this.Bind(_BermudanExercise)

(* 
    Externally visible/bindable properties
*)
    member this.dates                              = _dates 
    member this.payoffAtExpiry                     = _payoffAtExpiry 
    member this.PayoffAtExpiry                     = _payoffAtExpiry
    member this.Date                               index   
                                                   = _date index 
    member this.Dates                              = _dates
    member this.LastDate                           = _lastDate
    member this.Type                               = _type