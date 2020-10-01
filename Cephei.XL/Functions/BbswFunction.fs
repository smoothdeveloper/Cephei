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

(* <summary>
  Bbsw rate fixed by AFMA.  See <http://www.afma.com.au/data/BBSW>.
  </summary> *)
[<AutoSerializable(true)>]
module BbswFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Bbsw", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="tenor",Description = "Reference to tenor")>] 
         tenor : obj)
        ([<ExcelArgument(Name="h",Description = "Reference to h")>] 
         h : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _tenor = Helper.toCell<Period> tenor "tenor" 
                let _h = Helper.toHandle<YieldTermStructure> h "h" 
                let builder () = withMnemonic mnemonic (Fun.Bbsw 
                                                            _tenor.cell 
                                                            _h.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Bbsw>) l

                let source = Helper.sourceFold "Fun.Bbsw" 
                                               [| _tenor.source
                                               ;  _h.source
                                               |]
                let hash = Helper.hashFold 
                                [| _tenor.cell
                                ;  _h.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bbsw> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_Bbsw_businessDayConvention", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_businessDayConvention
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).BusinessDayConvention
                                                       ) :> ICell
                let format (o : BusinessDayConvention) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".BusinessDayConvention") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
        Other methods returns a copy of itself linked to a different forwarding curve
    *)
    [<ExcelFunction(Name="_Bbsw_clone", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_clone
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="forwarding",Description = "Reference to forwarding")>] 
         forwarding : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _forwarding = Helper.toHandle<YieldTermStructure> forwarding "forwarding" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).Clone
                                                            _forwarding.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<IborIndex>) l

                let source = Helper.sourceFold (_Bbsw.source + ".Clone") 
                                               [| _Bbsw.source
                                               ;  _forwarding.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _forwarding.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bbsw> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Bbsw_endOfMonth", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).EndOfMonth
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".EndOfMonth") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
    [<ExcelFunction(Name="_Bbsw_forecastFixing1", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_forecastFixing1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="d1",Description = "Reference to d1")>] 
         d1 : obj)
        ([<ExcelArgument(Name="d2",Description = "Reference to d2")>] 
         d2 : obj)
        ([<ExcelArgument(Name="t",Description = "Reference to t")>] 
         t : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _d1 = Helper.toCell<Date> d1 "d1" 
                let _d2 = Helper.toCell<Date> d2 "d2" 
                let _t = Helper.toCell<double> t "t" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).ForecastFixing1
                                                            _d1.cell 
                                                            _d2.cell 
                                                            _t.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".ForecastFixing1") 
                                               [| _Bbsw.source
                                               ;  _d1.source
                                               ;  _d2.source
                                               ;  _t.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _d1.cell
                                ;  _d2.cell
                                ;  _t.cell
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
    [<ExcelFunction(Name="_Bbsw_forecastFixing", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_forecastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).ForecastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".ForecastFixing") 
                                               [| _Bbsw.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _fixingDate.cell
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
        the curve used to forecast fixings
    *)
    [<ExcelFunction(Name="_Bbsw_forwardingTermStructure", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_forwardingTermStructure
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).ForwardingTermStructure
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Handle<YieldTermStructure>>) l

                let source = Helper.sourceFold (_Bbsw.source + ".ForwardingTermStructure") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bbsw> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        InterestRateIndex interface
    *)
    [<ExcelFunction(Name="_Bbsw_maturityDate", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).MaturityDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".MaturityDate") 
                                               [| _Bbsw.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_Bbsw_currency", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_currency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).Currency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_Bbsw.source + ".Currency") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bbsw> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Bbsw_dayCounter", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_Bbsw.source + ".DayCounter") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bbsw> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Inspectors
    *)
    [<ExcelFunction(Name="_Bbsw_familyName", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_familyName
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).FamilyName
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".FamilyName") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
    [<ExcelFunction(Name="_Bbsw_fixing", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_fixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        ([<ExcelArgument(Name="forecastTodaysFixing",Description = "Reference to forecastTodaysFixing")>] 
         forecastTodaysFixing : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let _forecastTodaysFixing = Helper.toCell<bool> forecastTodaysFixing "forecastTodaysFixing" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).Fixing
                                                            _fixingDate.cell 
                                                            _forecastTodaysFixing.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".Fixing") 
                                               [| _Bbsw.source
                                               ;  _fixingDate.source
                                               ;  _forecastTodaysFixing.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _fixingDate.cell
                                ;  _forecastTodaysFixing.cell
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
    [<ExcelFunction(Name="_Bbsw_fixingCalendar", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_fixingCalendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).FixingCalendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Bbsw.source + ".FixingCalendar") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bbsw> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Bbsw_fixingDate", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="valueDate",Description = "Reference to valueDate")>] 
         valueDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _valueDate = Helper.toCell<Date> valueDate "valueDate" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).FixingDate
                                                            _valueDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".FixingDate") 
                                               [| _Bbsw.source
                                               ;  _valueDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _valueDate.cell
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
    [<ExcelFunction(Name="_Bbsw_fixingDays", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".FixingDays") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
    [<ExcelFunction(Name="_Bbsw_isValidFixingDate", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_isValidFixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).IsValidFixingDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".IsValidFixingDate") 
                                               [| _Bbsw.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _fixingDate.cell
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
        Index interface
    *)
    [<ExcelFunction(Name="_Bbsw_name", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".Name") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
    [<ExcelFunction(Name="_Bbsw_pastFixing", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_pastFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).PastFixing
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".PastFixing") 
                                               [| _Bbsw.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _fixingDate.cell
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
    [<ExcelFunction(Name="_Bbsw_tenor", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_tenor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).Tenor
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_Bbsw.source + ".Tenor") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Bbsw> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Observer interface
    *)
    [<ExcelFunction(Name="_Bbsw_update", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).Update
                                                       ) :> ICell
                let format (o : Bbsw) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".Update") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
        Date calculations These methods can be overridden to implement particular conventions (e.g. EurLibor)
    *)
    [<ExcelFunction(Name="_Bbsw_valueDate", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_valueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="fixingDate",Description = "Reference to fixingDate")>] 
         fixingDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _fixingDate = Helper.toCell<Date> fixingDate "fixingDate" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).ValueDate
                                                            _fixingDate.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".ValueDate") 
                                               [| _Bbsw.source
                                               ;  _fixingDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _fixingDate.cell
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
        Stores the historical fixing at the given date The date passed as arguments must be the actual calendar date of the fixing; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_Bbsw_addFixing", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_addFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _d = Helper.toCell<Date> d "d" 
                let _v = Helper.toCell<double> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).AddFixing
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bbsw) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".AddFixing") 
                                               [| _Bbsw.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings at the given dates The dates passed as arguments must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_Bbsw_addFixings", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_addFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _d = Helper.toCell<Generic.List<Date>> d "d" 
                let _v = Helper.toCell<Generic.List<double>> v "v" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).AddFixings
                                                            _d.cell 
                                                            _v.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bbsw) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".AddFixings") 
                                               [| _Bbsw.source
                                               ;  _d.source
                                               ;  _v.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _d.cell
                                ;  _v.cell
                                ;  _forceOverwrite.cell
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
        Stores historical fixings from a TimeSeries The dates in the TimeSeries must be the actual calendar dates of the fixings; no settlement days must be used.
    *)
    [<ExcelFunction(Name="_Bbsw_addFixings1", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_addFixings1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="source",Description = "Reference to source")>] 
         source : obj)
        ([<ExcelArgument(Name="forceOverwrite",Description = "Reference to forceOverwrite")>] 
         forceOverwrite : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _source = Helper.toCell<TimeSeries<Nullable<double>>> source "source" 
                let _forceOverwrite = Helper.toCell<bool> forceOverwrite "forceOverwrite" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).AddFixings1
                                                            _source.cell 
                                                            _forceOverwrite.cell 
                                                       ) :> ICell
                let format (o : Bbsw) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".AddFixings1") 
                                               [| _Bbsw.source
                                               ;  _source.source
                                               ;  _forceOverwrite.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _source.cell
                                ;  _forceOverwrite.cell
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
        Check if index allows for native fixings. If this returns false, calls to addFixing and similar methods will raise an exception.
    *)
    [<ExcelFunction(Name="_Bbsw_allowsNativeFixings", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_allowsNativeFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).AllowsNativeFixings
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".AllowsNativeFixings") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
        Clears all stored historical fixings
    *)
    [<ExcelFunction(Name="_Bbsw_clearFixings", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_clearFixings
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).ClearFixings
                                                       ) :> ICell
                let format (o : Bbsw) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".ClearFixings") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
    [<ExcelFunction(Name="_Bbsw_registerWith", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Bbsw) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".RegisterWith") 
                                               [| _Bbsw.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _handler.cell
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
        Returns the fixing TimeSeries
    *)
    [<ExcelFunction(Name="_Bbsw_timeSeries", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_timeSeries
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).TimeSeries
                                                       ) :> ICell
                let format (o : TimeSeries<Nullable<double>>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".TimeSeries") 
                                               [| _Bbsw.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
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
    [<ExcelFunction(Name="_Bbsw_unregisterWith", Description="Create a Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Bbsw",Description = "Reference to Bbsw")>] 
         bbsw : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Bbsw = Helper.toCell<Bbsw> bbsw "Bbsw"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_Bbsw.cell :?> BbswModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : Bbsw) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Bbsw.source + ".UnregisterWith") 
                                               [| _Bbsw.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Bbsw.cell
                                ;  _handler.cell
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
    [<ExcelFunction(Name="_Bbsw_Range", Description="Create a range of Bbsw",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Bbsw_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Bbsw")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Bbsw> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Bbsw>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Bbsw>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Bbsw>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
