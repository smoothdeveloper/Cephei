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
  Intermediate class for payoffs based on a fixed strike

  </summary> *)
[<AutoSerializable(true)>]
type StrikedTypePayoffModel
    ( p                                            : ICell<Payoff>
    ) as this =

    inherit Model<StrikedTypePayoff> ()
(*
    Parameters
*)
    let _p                                         = p
(*
    Functions
*)
    let _StrikedTypePayoff                         = cell (fun () -> new StrikedTypePayoff (p.Value))
    let _description                               = cell (fun () -> _StrikedTypePayoff.Value.description())
    let _strike                                    = cell (fun () -> _StrikedTypePayoff.Value.strike())
    let _optionType                                = cell (fun () -> _StrikedTypePayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _StrikedTypePayoff.Value.accept(v.Value)
                                                                     _StrikedTypePayoff.Value)
    let _name                                      = cell (fun () -> _StrikedTypePayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = cell (fun () -> _StrikedTypePayoff.Value.value(price.Value))
    do this.Bind(_StrikedTypePayoff)

(* 
    Externally visible/bindable properties
*)
    member this.p                                  = _p 
    member this.Description                        = _description
    member this.Strike                             = _strike
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 
(* <summary>
  Intermediate class for payoffs based on a fixed strike

  </summary> *)
[<AutoSerializable(true)>]
type StrikedTypePayoffModel1
    ( Type                                         : ICell<Option.Type>
    , strike                                       : ICell<double>
    ) as this =

    inherit Model<StrikedTypePayoff> ()
(*
    Parameters
*)
    let _Type                                      = Type
    let _strike                                    = strike
(*
    Functions
*)
    let _StrikedTypePayoff                         = cell (fun () -> new StrikedTypePayoff (Type.Value, strike.Value))
    let _description                               = cell (fun () -> _StrikedTypePayoff.Value.description())
    let _strike                                    = cell (fun () -> _StrikedTypePayoff.Value.strike())
    let _optionType                                = cell (fun () -> _StrikedTypePayoff.Value.optionType())
    let _accept                                    (v : ICell<IAcyclicVisitor>)   
                                                   = cell (fun () -> _StrikedTypePayoff.Value.accept(v.Value)
                                                                     _StrikedTypePayoff.Value)
    let _name                                      = cell (fun () -> _StrikedTypePayoff.Value.name())
    let _value                                     (price : ICell<double>)   
                                                   = cell (fun () -> _StrikedTypePayoff.Value.value(price.Value))
    do this.Bind(_StrikedTypePayoff)

(* 
    Externally visible/bindable properties
*)
    member this.Type                               = _Type 
    member this.strike                             = _strike 
    member this.Description                        = _description
    member this.Strike                             = _strike
    member this.OptionType                         = _optionType
    member this.Accept                             v   
                                                   = _accept v 
    member this.Name                               = _name
    member this.Value                              price   
                                                   = _value price 