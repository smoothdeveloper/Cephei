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
  Holidays for the Singapore exchange (data from <http://www.sgx.com/wps/portal/sgxweb/home/trading/securities/trading_hours_calendar>):
<ul>
<li>Saturdays</li>
<li>Sundays</li>
<li>New Year's day, January 1st</li>
<li>Good Friday</li>
<li>Labour Day, May 1st</li>
<li>National Day, August 9th</li>
<li>Christmas, December 25th </li>
</ul>  Other holidays for which no rule is given (data available for 2004-2010, 2012-2013 only:)
<ul>
<li>Chinese New Year</li>
<li>Hari Raya Haji</li>
<li>Vesak Poya Day</li>
<li>Deepavali</li>
<li>Diwali</li>
<li>Hari Raya Puasa</li>
</ul>  calendars
  </summary> *)
[<AutoSerializable(true)>]
module SingaporeFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_Singapore", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.Singapore ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Singapore>) l

                let source = Helper.sourceFold "Fun.Singapore" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Singapore> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Singapore_addedHolidays", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_addedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).AddedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Singapore.source + ".AddedHolidays") 
                                               [| _Singapore.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
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
    [<ExcelFunction(Name="_Singapore_addHoliday", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_addHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).AddHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Singapore) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".AddHoliday") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_Singapore_adjust", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_adjust
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).Adjust
                                                            _d.cell 
                                                            _c.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".Adjust") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               ;  _c.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
                                ;  _c.cell
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
    [<ExcelFunction(Name="_Singapore_advance1", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_advance1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="n",Description = "Reference to n")>] 
         n : obj)
        ([<ExcelArgument(Name="unit",Description = "Reference to unit")>] 
         unit : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let _n = Helper.toCell<int> n "n" 
                let _unit = Helper.toCell<TimeUnit> unit "unit" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).Advance1
                                                            _d.cell 
                                                            _n.cell 
                                                            _unit.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".Advance") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               ;  _n.source
                                               ;  _unit.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
                                ;  _n.cell
                                ;  _unit.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_Singapore_advance", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_advance
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        ([<ExcelArgument(Name="p",Description = "Reference to p")>] 
         p : obj)
        ([<ExcelArgument(Name="c",Description = "Reference to c")>] 
         c : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let _p = Helper.toCell<Period> p "p" 
                let _c = Helper.toCell<BusinessDayConvention> c "c" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).Advance
                                                            _d.cell 
                                                            _p.cell 
                                                            _c.cell 
                                                            _endOfMonth.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".Advance") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               ;  _p.source
                                               ;  _c.source
                                               ;  _endOfMonth.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
                                ;  _p.cell
                                ;  _c.cell
                                ;  _endOfMonth.cell
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
    [<ExcelFunction(Name="_Singapore_businessDaysBetween", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_businessDaysBetween
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="from",Description = "Reference to from")>] 
         from : obj)
        ([<ExcelArgument(Name="To",Description = "Reference to To")>] 
         To : obj)
        ([<ExcelArgument(Name="includeFirst",Description = "Reference to includeFirst")>] 
         includeFirst : obj)
        ([<ExcelArgument(Name="includeLast",Description = "Reference to includeLast")>] 
         includeLast : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _from = Helper.toCell<Date> from "from" 
                let _To = Helper.toCell<Date> To "To" 
                let _includeFirst = Helper.toCell<bool> includeFirst "includeFirst" 
                let _includeLast = Helper.toCell<bool> includeLast "includeLast" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).BusinessDaysBetween
                                                            _from.cell 
                                                            _To.cell 
                                                            _includeFirst.cell 
                                                            _includeLast.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_Singapore.source + ".BusinessDaysBetween") 
                                               [| _Singapore.source
                                               ;  _from.source
                                               ;  _To.source
                                               ;  _includeFirst.source
                                               ;  _includeLast.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _from.cell
                                ;  _To.cell
                                ;  _includeFirst.cell
                                ;  _includeLast.cell
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
    [<ExcelFunction(Name="_Singapore_calendar", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_Singapore.source + ".Calendar") 
                                               [| _Singapore.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Singapore> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Returns whether or not the calendar is initialized
    *)
    [<ExcelFunction(Name="_Singapore_empty", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".Empty") 
                                               [| _Singapore.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
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
    [<ExcelFunction(Name="_Singapore_endOfMonth", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_endOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).EndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".EndOfMonth") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_Singapore_Equals", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".Equals") 
                                               [| _Singapore.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _o.cell
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
        @returns Returns <tt>true</tt> iff the date is a business day for the given market.
    *)
    [<ExcelFunction(Name="_Singapore_isBusinessDay", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_isBusinessDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).IsBusinessDay
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".IsBusinessDay") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_Singapore_isEndOfMonth", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_isEndOfMonth
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).IsEndOfMonth
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".IsEndOfMonth") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
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
        Returns <tt>true</tt> iff the date is a holiday for the given market.
    *)
    [<ExcelFunction(Name="_Singapore_isHoliday", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_isHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).IsHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".IsHoliday") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
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
        Returns <tt>true</tt> iff the weekday is part of the weekend for the given market.
    *)
    [<ExcelFunction(Name="_Singapore_isWeekend", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_isWeekend
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="w",Description = "Reference to w")>] 
         w : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _w = Helper.toCell<DayOfWeek> w "w" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).IsWeekend
                                                            _w.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".IsWeekend") 
                                               [| _Singapore.source
                                               ;  _w.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _w.cell
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
        This method is used for output and comparison between calendars. It is <b>not</b> meant to be used for writing switch-on-type code.

@returns The name of the calendar.
    *)
    [<ExcelFunction(Name="_Singapore_name", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".Name") 
                                               [| _Singapore.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
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
    [<ExcelFunction(Name="_Singapore_removedHolidays", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_removedHolidays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).RemovedHolidays
                                                       ) :> ICell
                let format (i : Generic.List<ICell<Date>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_Singapore.source + ".RemovedHolidays") 
                                               [| _Singapore.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
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
    [<ExcelFunction(Name="_Singapore_removeHoliday", Description="Create a Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_removeHoliday
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Singapore",Description = "Reference to Singapore")>] 
         singapore : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Singapore = Helper.toCell<Singapore> singapore "Singapore"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_Singapore.cell :?> SingaporeModel).RemoveHoliday
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : Singapore) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Singapore.source + ".RemoveHoliday") 
                                               [| _Singapore.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Singapore.cell
                                ;  _d.cell
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
    [<ExcelFunction(Name="_Singapore_Range", Description="Create a range of Singapore",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Singapore_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Singapore")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Singapore> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Singapore>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Singapore>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Singapore>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"