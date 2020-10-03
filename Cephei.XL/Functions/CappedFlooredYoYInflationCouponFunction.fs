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
  Essentially a copy of the nominal version but taking a different index and a set of pricers (not just one).  The payoff P of a capped inflation-rate coupon with paysWithin = true is:  P = N T L + b, C).  where N is the notional, T is the accrual time, L is the inflation rate, a is its gearing, b is the spread, and C and F the strikes.  The payoff of a floored inflation-rate coupon is:  P = N T L + b, F).  The payoff of a collared inflation-rate coupon is:  P = N T L + b, F), C).  If paysWithin = false then the inverse is returned (this provides for instrument cap and caplet prices).  They can be decomposed in the following manner.  Decomposition of a capped floating rate coupon when paysWithin = true: R = L + b, C) = (a L + b) + - b - |a| L, 0) where = sgn(a) Then: R = (a L + b) + |a| - b}{|a|} - L, 0)
  </summary> *)
[<AutoSerializable(true)>]
module CappedFlooredYoYInflationCouponFunction =

    (*
        ! cap
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_cap", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_cap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Cap
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Cap") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ... or not
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="paymentDate",Description = "Reference to paymentDate")>] 
         paymentDate : obj)
        ([<ExcelArgument(Name="nominal",Description = "Reference to nominal")>] 
         nominal : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="endDate",Description = "Reference to endDate")>] 
         endDate : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="index",Description = "Reference to index")>] 
         index : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="gearing",Description = "Reference to gearing")>] 
         gearing : obj)
        ([<ExcelArgument(Name="spread",Description = "Reference to spread")>] 
         spread : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "Reference to floor")>] 
         floor : obj)
        ([<ExcelArgument(Name="refPeriodStart",Description = "Reference to refPeriodStart")>] 
         refPeriodStart : obj)
        ([<ExcelArgument(Name="refPeriodEnd",Description = "Reference to refPeriodEnd")>] 
         refPeriodEnd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _paymentDate = Helper.toCell<Date> paymentDate "paymentDate" 
                let _nominal = Helper.toCell<double> nominal "nominal" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _endDate = Helper.toCell<Date> endDate "endDate" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _index = Helper.toCell<YoYInflationIndex> index "index" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _gearing = Helper.toDefault<double> gearing "gearing" 1.0
                let _spread = Helper.toDefault<double> spread "spread" 0.0
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let _refPeriodStart = Helper.toDefault<Date> refPeriodStart "refPeriodStart" null
                let _refPeriodEnd = Helper.toDefault<Date> refPeriodEnd "refPeriodEnd" null
                let builder () = withMnemonic mnemonic (Fun.CappedFlooredYoYInflationCoupon 
                                                            _paymentDate.cell 
                                                            _nominal.cell 
                                                            _startDate.cell 
                                                            _endDate.cell 
                                                            _fixingDays.cell 
                                                            _index.cell 
                                                            _observationLag.cell 
                                                            _dayCounter.cell 
                                                            _gearing.cell 
                                                            _spread.cell 
                                                            _cap.cell 
                                                            _floor.cell 
                                                            _refPeriodStart.cell 
                                                            _refPeriodEnd.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredYoYInflationCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredYoYInflationCoupon" 
                                               [| _paymentDate.source
                                               ;  _nominal.source
                                               ;  _startDate.source
                                               ;  _endDate.source
                                               ;  _fixingDays.source
                                               ;  _index.source
                                               ;  _observationLag.source
                                               ;  _dayCounter.source
                                               ;  _gearing.source
                                               ;  _spread.source
                                               ;  _cap.source
                                               ;  _floor.source
                                               ;  _refPeriodStart.source
                                               ;  _refPeriodEnd.source
                                               |]
                let hash = Helper.hashFold 
                                [| _paymentDate.cell
                                ;  _nominal.cell
                                ;  _startDate.cell
                                ;  _endDate.cell
                                ;  _fixingDays.cell
                                ;  _index.cell
                                ;  _observationLag.cell
                                ;  _dayCounter.cell
                                ;  _gearing.cell
                                ;  _spread.cell
                                ;  _cap.cell
                                ;  _floor.cell
                                ;  _refPeriodStart.cell
                                ;  _refPeriodEnd.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredYoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        we may watch an underlying coupon ...
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon1", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="underlying",Description = "Reference to underlying")>] 
         underlying : obj)
        ([<ExcelArgument(Name="cap",Description = "Reference to cap")>] 
         cap : obj)
        ([<ExcelArgument(Name="floor",Description = "Reference to floor")>] 
         floor : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _underlying = Helper.toCell<YoYInflationCoupon> underlying "underlying" 
                let _cap = Helper.toNullable<double> cap "cap"
                let _floor = Helper.toNullable<double> floor "floor"
                let builder () = withMnemonic mnemonic (Fun.CappedFlooredYoYInflationCoupon1 
                                                            _underlying.cell 
                                                            _cap.cell 
                                                            _floor.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CappedFlooredYoYInflationCoupon>) l

                let source = Helper.sourceFold "Fun.CappedFlooredYoYInflationCoupon1" 
                                               [| _underlying.source
                                               ;  _cap.source
                                               ;  _floor.source
                                               |]
                let hash = Helper.hashFold 
                                [| _underlying.cell
                                ;  _cap.cell
                                ;  _floor.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredYoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! effective cap of fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_effectiveCap", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_effectiveCap
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).EffectiveCap
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".EffectiveCap") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! effective floor of fixing
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_effectiveFloor", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_effectiveFloor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).EffectiveFloor
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".EffectiveFloor") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! floor
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_floor", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_floor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Floor
                                                       ) :> ICell
                let format (o : Nullable<double>) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Floor") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_isCapped", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_isCapped
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).IsCapped
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".IsCapped") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_isFloored", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_isFloored
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).IsFloored
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".IsFloored") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        augmented Coupon interface swap(let) rate
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_rate", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_rate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Rate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Rate") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_setPricer", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_setPricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="pricer",Description = "Reference to pricer")>] 
         pricer : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _pricer = Helper.toCell<YoYInflationCouponPricer> pricer "pricer" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).SetPricer
                                                            _pricer.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredYoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".SetPricer") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _pricer.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                ;  _pricer.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_adjustedFixing", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_adjustedFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AdjustedFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AdjustedFixing") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        Inspectors index gearing, i.e. multiplicative coefficient for the index
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_gearing", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_gearing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Gearing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Gearing") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! spread paid over the fixing of the underlying index
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_spread", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_spread
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Spread
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Spread") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_yoyIndex", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_yoyIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).YoyIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<YoYInflationIndex>) l

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".YoyIndex") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredYoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accruedAmount", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AccruedAmount
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AccruedAmount") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_amount", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_amount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Amount
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Amount") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_dayCounter", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".DayCounter") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredYoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixing date
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_fixingDate", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_fixingDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).FixingDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".FixingDate") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! fixing days
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_fixingDays", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_fixingDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).FixingDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".FixingDays") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        Inspectors ! yoy inflation index
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_index", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_index
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Index
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationIndex>) l

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Index") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredYoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! fixing of the underlying index, as observed by the coupon
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_indexFixing", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_indexFixing
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).IndexFixing
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".IndexFixing") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! how the coupon observes the index
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_observationLag", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".ObservationLag") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredYoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        Coupon interface
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_price", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_price
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="discountingCurve",Description = "Reference to discountingCurve")>] 
         discountingCurve : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _discountingCurve = Helper.toHandle<YieldTermStructure> discountingCurve "discountingCurve" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Price
                                                            _discountingCurve.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Price") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _discountingCurve.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                ;  _discountingCurve.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_pricer", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_pricer
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Pricer
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<InflationCouponPricer>) l

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Pricer") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CappedFlooredYoYInflationCoupon> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_update", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_update
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Update
                                                       ) :> ICell
                let format (o : CappedFlooredYoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Update") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! accrual period in days
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accrualDays", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accrualDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AccrualDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AccrualDays") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! end of the accrual period
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accrualEndDate", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accrualEndDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AccrualEndDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AccrualEndDate") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! accrual period as fraction of year
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accrualPeriod", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accrualPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AccrualPeriod
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AccrualPeriod") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! start of the accrual period
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accrualStartDate", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accrualStartDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AccrualStartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AccrualStartDate") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! accrued days at the given date
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accruedDays", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accruedDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AccruedDays
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AccruedDays") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! accrued period as fraction of year at the given date
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accruedPeriod", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accruedPeriod
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).AccruedPeriod
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".AccruedPeriod") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        Event interface
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_date", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_date
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Date
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Date") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        CashFlow interface
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_exCouponDate", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_exCouponDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).ExCouponDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".ExCouponDate") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        Inspectors
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_nominal", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_nominal
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Nominal
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Nominal") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! end date of the reference period
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_referencePeriodEnd", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_referencePeriodEnd
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).ReferencePeriodEnd
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".ReferencePeriodEnd") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        ! start date of the reference period
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_referencePeriodStart", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_referencePeriodStart
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).ReferencePeriodStart
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".ReferencePeriodStart") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_CompareTo", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_CompareTo
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _cf = Helper.toCell<CashFlow> cf "cf" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).CompareTo
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".CompareTo") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_Equals", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="cf",Description = "Reference to cf")>] 
         cf : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _cf = Helper.toCell<Object> cf "cf" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Equals
                                                            _cf.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Equals") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _cf.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                ;  _cf.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_hasOccurred", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_hasOccurred
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        ([<ExcelArgument(Name="includeRefDate",Description = "Reference to includeRefDate")>] 
         includeRefDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let _includeRefDate = Helper.toNullable<bool> includeRefDate "includeRefDate"
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).HasOccurred
                                                            _refDate.cell 
                                                            _includeRefDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".HasOccurred") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _refDate.source
                                               ;  _includeRefDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                ;  _refDate.cell
                                ;  _includeRefDate.cell
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
        ! returns true if the cashflow is trading ex-coupon on the refDate
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_tradingExCoupon", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_tradingExCoupon
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="refDate",Description = "Reference to refDate")>] 
         refDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _refDate = Helper.toCell<Date> refDate "refDate" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).TradingExCoupon
                                                            _refDate.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".TradingExCoupon") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _refDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                ;  _refDate.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_accept", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_accept
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="v",Description = "Reference to v")>] 
         v : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _v = Helper.toCell<IAcyclicVisitor> v "v" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).Accept
                                                            _v.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredYoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".Accept") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _v.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
                                ;  _v.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_registerWith", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_registerWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).RegisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredYoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".RegisterWith") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
        
    *)
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_unregisterWith", Description="Create a CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_unregisterWith
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CappedFlooredYoYInflationCoupon",Description = "Reference to CappedFlooredYoYInflationCoupon")>] 
         cappedflooredyoyinflationcoupon : obj)
        ([<ExcelArgument(Name="handler",Description = "Reference to handler")>] 
         handler : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CappedFlooredYoYInflationCoupon = Helper.toCell<CappedFlooredYoYInflationCoupon> cappedflooredyoyinflationcoupon "CappedFlooredYoYInflationCoupon"  
                let _handler = Helper.toCell<Callback> handler "handler" 
                let builder () = withMnemonic mnemonic ((_CappedFlooredYoYInflationCoupon.cell :?> CappedFlooredYoYInflationCouponModel).UnregisterWith
                                                            _handler.cell 
                                                       ) :> ICell
                let format (o : CappedFlooredYoYInflationCoupon) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CappedFlooredYoYInflationCoupon.source + ".UnregisterWith") 
                                               [| _CappedFlooredYoYInflationCoupon.source
                                               ;  _handler.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CappedFlooredYoYInflationCoupon.cell
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
    [<ExcelFunction(Name="_CappedFlooredYoYInflationCoupon_Range", Description="Create a range of CappedFlooredYoYInflationCoupon",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CappedFlooredYoYInflationCoupon_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CappedFlooredYoYInflationCoupon")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CappedFlooredYoYInflationCoupon> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CappedFlooredYoYInflationCoupon>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CappedFlooredYoYInflationCoupon>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CappedFlooredYoYInflationCoupon>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"