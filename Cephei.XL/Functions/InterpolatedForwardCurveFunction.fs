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
namespace Cephei.XL

open ExcelDna.Integration
open Cephei.Cell
open Cephei.Cell.Generic
open Cephei.QL
open System.Collections
open System
open System.Linq
open QLNet
open Cephei.XL.Helper

(*!1 generic
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module InterpolatedForwardCurveFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_Clone", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_Clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Clone
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Clone") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_data", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_data
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Data
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Data") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_data_", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_data_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Data_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Data_") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_dates", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_dates
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Dates
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Dates") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_dates_", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_dates_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Dates_
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Dates_") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_forwards", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_forwards
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Forwards
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Forwards") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="forwards",Description = "Reference to forwards")>] 
         forwards : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _forwards = Helper.toCell<Generic.List<double>> forwards "forwards" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedForwardCurve 
                                                            _dates.cell 
                                                            _forwards.cell 
                                                            _dayCounter.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedForwardCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedForwardCurve" 
                                               [| _dates.source
                                               ;  _forwards.source
                                               ;  _dayCounter.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _forwards.cell
                                ;  _dayCounter.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve1", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="forwards",Description = "Reference to forwards")>] 
         forwards : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _forwards = Helper.toCell<Generic.List<double>> forwards "forwards" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedForwardCurve1 
                                                            _dates.cell 
                                                            _forwards.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedForwardCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedForwardCurve1" 
                                               [| _dates.source
                                               ;  _forwards.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _forwards.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve2", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_create2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="forwards",Description = "Reference to forwards")>] 
         forwards : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _forwards = Helper.toCell<Generic.List<double>> forwards "forwards" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedForwardCurve2 
                                                            _dates.cell 
                                                            _forwards.cell 
                                                            _dayCounter.cell 
                                                            _calendar.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedForwardCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedForwardCurve2" 
                                               [| _dates.source
                                               ;  _forwards.source
                                               ;  _dayCounter.source
                                               ;  _calendar.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _forwards.cell
                                ;  _dayCounter.cell
                                ;  _calendar.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve3", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_create3
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _calendar = Helper.toDefault<Calendar> calendar "calendar" null
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedForwardCurve3 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedForwardCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedForwardCurve3" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve4", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_create4
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedForwardCurve4 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedForwardCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedForwardCurve4" 
                                               [| _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve5", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_create5
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="referenceDate",Description = "Reference to referenceDate")>] 
         referenceDate : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _referenceDate = Helper.toCell<Date> referenceDate "referenceDate" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedForwardCurve5 
                                                            _referenceDate.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedForwardCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedForwardCurve5" 
                                               [| _referenceDate.source
                                               ;  _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _referenceDate.cell
                                ;  _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve6", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_create6
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="dates",Description = "Reference to dates")>] 
         dates : obj)
        ([<ExcelArgument(Name="forwards",Description = "Reference to forwards")>] 
         forwards : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="jumps",Description = "Reference to jumps")>] 
         jumps : obj)
        ([<ExcelArgument(Name="jumpDates",Description = "Reference to jumpDates")>] 
         jumpDates : obj)
        ([<ExcelArgument(Name="interpolator",Description = "Reference to interpolator")>] 
         interpolator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _dates = Helper.toCell<Generic.List<Date>> dates "dates" 
                let _forwards = Helper.toCell<Generic.List<double>> forwards "forwards" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _jumps = Helper.toDefault<Generic.List<Handle<Quote>>> jumps "jumps" null
                let _jumpDates = Helper.toDefault<Generic.List<Date>> jumpDates "jumpDates" null
                let _interpolator = Helper.toDefault<'Interpolator> interpolator "interpolator" default(Interpolator)
                let builder () = withMnemonic mnemonic (Fun.InterpolatedForwardCurve6 
                                                            _dates.cell 
                                                            _forwards.cell 
                                                            _dayCounter.cell 
                                                            _jumps.cell 
                                                            _jumpDates.cell 
                                                            _interpolator.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InterpolatedForwardCurve>) l

                let source = Helper.sourceFold "Fun.InterpolatedForwardCurve6" 
                                               [| _dates.source
                                               ;  _forwards.source
                                               ;  _dayCounter.source
                                               ;  _jumps.source
                                               ;  _jumpDates.source
                                               ;  _interpolator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _dates.cell
                                ;  _forwards.cell
                                ;  _dayCounter.cell
                                ;  _jumps.cell
                                ;  _jumpDates.cell
                                ;  _interpolator.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_interpolation_", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_interpolation_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Interpolation_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Interpolation>) l

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Interpolation_") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_interpolator_", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_interpolator_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Interpolator_
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IInterpolationFactory>) l

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Interpolator_") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<InterpolatedForwardCurve> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_maxDate", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_maxDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).MaxDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".MaxDate") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_maxDate_", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_maxDate_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).MaxDate_
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".MaxDate_") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_nodes", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_nodes
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Nodes
                                                       ) :> ICell
                let format (o : Dictionary<Date,double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Nodes") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_setupInterpolation", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_setupInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).SetupInterpolation
                                                       ) :> ICell
                let format (o : InterpolatedForwardCurve) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".SetupInterpolation") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriber format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_times", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_times
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Times
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Times") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_InterpolatedForwardCurve_times_", Description="Create a InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_times_
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="InterpolatedForwardCurve",Description = "Reference to InterpolatedForwardCurve")>] 
         interpolatedforwardcurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _InterpolatedForwardCurve = Helper.toCell<InterpolatedForwardCurve> interpolatedforwardcurve "InterpolatedForwardCurve"  
                let builder () = withMnemonic mnemonic ((_InterpolatedForwardCurve.cell :?> InterpolatedForwardCurveModel).Times_
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_InterpolatedForwardCurve.source + ".Times_") 
                                               [| _InterpolatedForwardCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _InterpolatedForwardCurve.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberRange format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_InterpolatedForwardCurve_Range", Description="Create a range of InterpolatedForwardCurve",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let InterpolatedForwardCurve_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the InterpolatedForwardCurve")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<InterpolatedForwardCurve> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<InterpolatedForwardCurve>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<InterpolatedForwardCurve>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<InterpolatedForwardCurve>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)