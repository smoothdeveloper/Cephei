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
  3-weeks %Euribor index

  </summary> *)
[<AutoSerializable(true)>]
type Euribor3WModel
    ( h                                            : ICell<Handle<YieldTermStructure>>
    ) as this =

    inherit Model<Euribor3W> ()
(*
    Parameters
*)
    let _h                                         = h
(*
    Functions
*)
    let mutable
        _Euribor3W                                 = cell (fun () -> new Euribor3W (h.Value))
    let _businessDayConvention                     = triv (fun () -> _Euribor3W.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _Euribor3W.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _Euribor3W.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _Euribor3W.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _Euribor3W.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.maturityDate(valueDate.Value))
    let _currency                                  = triv (fun () -> _Euribor3W.Value.currency())
    let _dayCounter                                = triv (fun () -> _Euribor3W.Value.dayCounter())
    let _familyName                                = triv (fun () -> _Euribor3W.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _Euribor3W.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _Euribor3W.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _Euribor3W.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _Euribor3W.Value.tenor())
    let _update                                    = triv (fun () -> _Euribor3W.Value.update()
                                                                     _Euribor3W.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _Euribor3W.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _Euribor3W.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _Euribor3W.Value)
    let _allowsNativeFixings                       = triv (fun () -> _Euribor3W.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _Euribor3W.Value.clearFixings()
                                                                     _Euribor3W.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Euribor3W.Value.registerWith(handler.Value)
                                                                     _Euribor3W.Value)
    let _timeSeries                                = triv (fun () -> _Euribor3W.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Euribor3W.Value.unregisterWith(handler.Value)
                                                                     _Euribor3W.Value)
    do this.Bind(_Euribor3W)
(* 
    casting 
*)
    internal new () = new Euribor3WModel(null)
    member internal this.Inject v = _Euribor3W <- v
    static member Cast (p : ICell<Euribor3W>) = 
        if p :? Euribor3WModel then 
            p :?> Euribor3WModel
        else
            let o = new Euribor3WModel ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.h                                  = _h 
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
(* <summary>
  3-weeks %Euribor index

  </summary> *)
[<AutoSerializable(true)>]
type Euribor3WModel1
    () as this =
    inherit Model<Euribor3W> ()
(*
    Parameters
*)
(*
    Functions
*)
    let mutable
        _Euribor3W                                 = cell (fun () -> new Euribor3W ())
    let _businessDayConvention                     = triv (fun () -> _Euribor3W.Value.businessDayConvention())
    let _clone                                     (forwarding : ICell<Handle<YieldTermStructure>>)   
                                                   = triv (fun () -> _Euribor3W.Value.clone(forwarding.Value))
    let _endOfMonth                                = triv (fun () -> _Euribor3W.Value.endOfMonth())
    let _forecastFixing                            (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.forecastFixing(fixingDate.Value))
    let _forecastFixing1                           (d1 : ICell<Date>) (d2 : ICell<Date>) (t : ICell<double>)   
                                                   = triv (fun () -> _Euribor3W.Value.forecastFixing(d1.Value, d2.Value, t.Value))
    let _forwardingTermStructure                   = triv (fun () -> _Euribor3W.Value.forwardingTermStructure())
    let _maturityDate                              (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.maturityDate(valueDate.Value))
    let _currency                                  = triv (fun () -> _Euribor3W.Value.currency())
    let _dayCounter                                = triv (fun () -> _Euribor3W.Value.dayCounter())
    let _familyName                                = triv (fun () -> _Euribor3W.Value.familyName())
    let _fixing                                    (fixingDate : ICell<Date>) (forecastTodaysFixing : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.fixing(fixingDate.Value, forecastTodaysFixing.Value))
    let _fixingCalendar                            = triv (fun () -> _Euribor3W.Value.fixingCalendar())
    let _fixingDate                                (valueDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.fixingDate(valueDate.Value))
    let _fixingDays                                = triv (fun () -> _Euribor3W.Value.fixingDays())
    let _isValidFixingDate                         (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.isValidFixingDate(fixingDate.Value))
    let _name                                      = triv (fun () -> _Euribor3W.Value.name())
    let _pastFixing                                (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.pastFixing(fixingDate.Value))
    let _tenor                                     = triv (fun () -> _Euribor3W.Value.tenor())
    let _update                                    = triv (fun () -> _Euribor3W.Value.update()
                                                                     _Euribor3W.Value)
    let _valueDate                                 (fixingDate : ICell<Date>)   
                                                   = triv (fun () -> _Euribor3W.Value.valueDate(fixingDate.Value))
    let _addFixing                                 (d : ICell<Date>) (v : ICell<double>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.addFixing(d.Value, v.Value, forceOverwrite.Value)
                                                                     _Euribor3W.Value)
    let _addFixings                                (d : ICell<Generic.List<Date>>) (v : ICell<Generic.List<double>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.addFixings(d.Value, v.Value, forceOverwrite.Value)
                                                                     _Euribor3W.Value)
    let _addFixings1                               (source : ICell<TimeSeries<Nullable<double>>>) (forceOverwrite : ICell<bool>)   
                                                   = triv (fun () -> _Euribor3W.Value.addFixings(source.Value, forceOverwrite.Value)
                                                                     _Euribor3W.Value)
    let _allowsNativeFixings                       = triv (fun () -> _Euribor3W.Value.allowsNativeFixings())
    let _clearFixings                              = triv (fun () -> _Euribor3W.Value.clearFixings()
                                                                     _Euribor3W.Value)
    let _registerWith                              (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Euribor3W.Value.registerWith(handler.Value)
                                                                     _Euribor3W.Value)
    let _timeSeries                                = triv (fun () -> _Euribor3W.Value.timeSeries())
    let _unregisterWith                            (handler : ICell<Callback>)   
                                                   = triv (fun () -> _Euribor3W.Value.unregisterWith(handler.Value)
                                                                     _Euribor3W.Value)
    do this.Bind(_Euribor3W)
(* 
    casting 
*)
    
    member internal this.Inject v = _Euribor3W <- v
    static member Cast (p : ICell<Euribor3W>) = 
        if p :? Euribor3WModel1 then 
            p :?> Euribor3WModel1
        else
            let o = new Euribor3WModel1 ()
            o.Inject p
            o.Bind p
            o
                            

(* 
    Externally visible/bindable properties
*)
    member this.BusinessDayConvention              = _businessDayConvention
    member this.Clone                              forwarding   
                                                   = _clone forwarding 
    member this.EndOfMonth                         = _endOfMonth
    member this.ForecastFixing                     fixingDate   
                                                   = _forecastFixing fixingDate 
    member this.ForecastFixing1                    d1 d2 t   
                                                   = _forecastFixing1 d1 d2 t 
    member this.ForwardingTermStructure            = _forwardingTermStructure
    member this.MaturityDate                       valueDate   
                                                   = _maturityDate valueDate 
    member this.Currency                           = _currency
    member this.DayCounter                         = _dayCounter
    member this.FamilyName                         = _familyName
    member this.Fixing                             fixingDate forecastTodaysFixing   
                                                   = _fixing fixingDate forecastTodaysFixing 
    member this.FixingCalendar                     = _fixingCalendar
    member this.FixingDate                         valueDate   
                                                   = _fixingDate valueDate 
    member this.FixingDays                         = _fixingDays
    member this.IsValidFixingDate                  fixingDate   
                                                   = _isValidFixingDate fixingDate 
    member this.Name                               = _name
    member this.PastFixing                         fixingDate   
                                                   = _pastFixing fixingDate 
    member this.Tenor                              = _tenor
    member this.Update                             = _update
    member this.ValueDate                          fixingDate   
                                                   = _valueDate fixingDate 
    member this.AddFixing                          d v forceOverwrite   
                                                   = _addFixing d v forceOverwrite 
    member this.AddFixings                         d v forceOverwrite   
                                                   = _addFixings d v forceOverwrite 
    member this.AddFixings1                        source forceOverwrite   
                                                   = _addFixings1 source forceOverwrite 
    member this.AllowsNativeFixings                = _allowsNativeFixings
    member this.ClearFixings                       = _clearFixings
    member this.RegisterWith                       handler   
                                                   = _registerWith handler 
    member this.TimeSeries                         = _timeSeries
    member this.UnregisterWith                     handler   
                                                   = _unregisterWith handler 
