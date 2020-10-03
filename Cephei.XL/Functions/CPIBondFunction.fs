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
  instruments
  </summary> *)
[<AutoSerializable(true)>]
module CPIBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_baseCPI", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_baseCPI
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).BaseCPI
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".BaseCPI") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="growthOnly",Description = "Reference to growthOnly")>] 
         growthOnly : obj)
        ([<ExcelArgument(Name="baseCPI",Description = "Reference to baseCPI")>] 
         baseCPI : obj)
        ([<ExcelArgument(Name="observationLag",Description = "Reference to observationLag")>] 
         observationLag : obj)
        ([<ExcelArgument(Name="cpiIndex",Description = "Reference to cpiIndex")>] 
         cpiIndex : obj)
        ([<ExcelArgument(Name="observationInterpolation",Description = "Reference to observationInterpolation")>] 
         observationInterpolation : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="fixedRate",Description = "Reference to fixedRate")>] 
         fixedRate : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="paymentCalendar",Description = "Reference to paymentCalendar")>] 
         paymentCalendar : obj)
        ([<ExcelArgument(Name="exCouponPeriod",Description = "Reference to exCouponPeriod")>] 
         exCouponPeriod : obj)
        ([<ExcelArgument(Name="exCouponCalendar",Description = "Reference to exCouponCalendar")>] 
         exCouponCalendar : obj)
        ([<ExcelArgument(Name="exCouponConvention",Description = "Reference to exCouponConvention")>] 
         exCouponConvention : obj)
        ([<ExcelArgument(Name="exCouponEndOfMonth",Description = "Reference to exCouponEndOfMonth")>] 
         exCouponEndOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _growthOnly = Helper.toCell<bool> growthOnly "growthOnly" 
                let _baseCPI = Helper.toCell<double> baseCPI "baseCPI" 
                let _observationLag = Helper.toCell<Period> observationLag "observationLag" 
                let _cpiIndex = Helper.toCell<ZeroInflationIndex> cpiIndex "cpiIndex" 
                let _observationInterpolation = Helper.toCell<InterpolationType> observationInterpolation "observationInterpolation" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _fixedRate = Helper.toCell<Generic.List<double>> fixedRate "fixedRate" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.ModifiedFollowing
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _paymentCalendar = Helper.toDefault<Calendar> paymentCalendar "paymentCalendar" null
                let _exCouponPeriod = Helper.toDefault<Period> exCouponPeriod "exCouponPeriod" null
                let _exCouponCalendar = Helper.toDefault<Calendar> exCouponCalendar "exCouponCalendar" null
                let _exCouponConvention = Helper.toDefault<BusinessDayConvention> exCouponConvention "exCouponConvention" BusinessDayConvention.Unadjusted
                let _exCouponEndOfMonth = Helper.toDefault<bool> exCouponEndOfMonth "exCouponEndOfMonth" false
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.CPIBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _growthOnly.cell 
                                                            _baseCPI.cell 
                                                            _observationLag.cell 
                                                            _cpiIndex.cell 
                                                            _observationInterpolation.cell 
                                                            _schedule.cell 
                                                            _fixedRate.cell 
                                                            _accrualDayCounter.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _paymentCalendar.cell 
                                                            _exCouponPeriod.cell 
                                                            _exCouponCalendar.cell 
                                                            _exCouponConvention.cell 
                                                            _exCouponEndOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CPIBond>) l

                let source = Helper.sourceFold "Fun.CPIBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _growthOnly.source
                                               ;  _baseCPI.source
                                               ;  _observationLag.source
                                               ;  _cpiIndex.source
                                               ;  _observationInterpolation.source
                                               ;  _schedule.source
                                               ;  _fixedRate.source
                                               ;  _accrualDayCounter.source
                                               ;  _paymentConvention.source
                                               ;  _issueDate.source
                                               ;  _paymentCalendar.source
                                               ;  _exCouponPeriod.source
                                               ;  _exCouponCalendar.source
                                               ;  _exCouponConvention.source
                                               ;  _exCouponEndOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _growthOnly.cell
                                ;  _baseCPI.cell
                                ;  _observationLag.cell
                                ;  _cpiIndex.cell
                                ;  _observationInterpolation.cell
                                ;  _schedule.cell
                                ;  _fixedRate.cell
                                ;  _accrualDayCounter.cell
                                ;  _paymentConvention.cell
                                ;  _issueDate.cell
                                ;  _paymentCalendar.cell
                                ;  _exCouponPeriod.cell
                                ;  _exCouponCalendar.cell
                                ;  _exCouponConvention.cell
                                ;  _exCouponEndOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_cpiIndex", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_cpiIndex
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).CpiIndex
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<ZeroInflationIndex>) l

                let source = Helper.sourceFold (_CPIBond.source + ".CpiIndex") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_dayCounter", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_CPIBond.source + ".DayCounter") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_CPIBond_frequency", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".Frequency") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_growthOnly", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_growthOnly
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).GrowthOnly
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".GrowthOnly") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_observationInterpolation", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_observationInterpolation
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).ObservationInterpolation
                                                       ) :> ICell
                let format (o : InterpolationType) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".ObservationInterpolation") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_observationLag", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_observationLag
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).ObservationLag
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Period>) l

                let source = Helper.sourceFold (_CPIBond.source + ".ObservationLag") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_accruedAmount", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".AccruedAmount") 
                                               [| _CPIBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_CPIBond_calendar", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CPIBond.source + ".Calendar") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        \note returns all the cashflows, including the redemptions.
    *)
    [<ExcelFunction(Name="_CPIBond_cashflows", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CPIBond.source + ".Cashflows") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_CPIBond_cleanPrice", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".CleanPrice") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_cleanPrice1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".CleanPrice1") 
                                               [| _CPIBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_dirtyPrice1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="Yield",Description = "Reference to Yield")>] 
         Yield : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".DirtyPrice1") 
                                               [| _CPIBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _Yield.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
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
        ! The default bond settlement is used for calculation.  \warning the theoretical price calculated from a flat term structure might differ slightly from the price calculated from the corresponding yield by means of the other overload of this function. If the price from a constant yield is desired, it is advisable to use such other overload.
    *)
    [<ExcelFunction(Name="_CPIBond_dirtyPrice", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".DirtyPrice") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_isExpired", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".IsExpired") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_issueDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".IssueDate") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_isTradable", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".IsTradable") 
                                               [| _CPIBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_maturityDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".MaturityDate") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_nextCashFlowDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".NextCashFlowDate") 
                                               [| _CPIBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
        ! Expected next coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the already-fixed not-yet-paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_nextCouponRate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".NextCouponRate") 
                                               [| _CPIBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
    [<ExcelFunction(Name="_CPIBond_notional", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".Notional") 
                                               [| _CPIBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_notionals", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CPIBond.source + ".Notionals") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_previousCashFlowDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".PreviousCashFlowDate") 
                                               [| _CPIBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
        ! Expected previous coupon: depending on (the bond and) the given date the coupon can be historic, deterministic or expected in a stochastic sense. When the bond settlement date is used the coupon is the last paid one.  The current bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_previousCouponRate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".PreviousCouponRate") 
                                               [| _CPIBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _settlement.cell
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
        returns the redemption, if only one is defined
    *)
    [<ExcelFunction(Name="_CPIBond_redemption", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_CPIBond.source + ".Redemption") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CPIBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! returns just the redemption flows (not interest payments)
    *)
    [<ExcelFunction(Name="_CPIBond_redemptions", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CPIBond.source + ".Redemptions") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".SettlementDate") 
                                               [| _CPIBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _date.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementDays", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".SettlementDays") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementValue", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".SettlementValue") 
                                               [| _CPIBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _cleanPrice.cell
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
    [<ExcelFunction(Name="_CPIBond_settlementValue1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".SettlementValue1") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_startDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".StartDate") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
        ! The default bond settlement is used if no date is given.
    *)
    [<ExcelFunction(Name="_CPIBond_yield1", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".Yield1") 
                                               [| _CPIBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _cleanPrice.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
        ! The default bond settlement and theoretical price are used for calculation.
    *)
    [<ExcelFunction(Name="_CPIBond_yield", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="dc",Description = "Reference to dc")>] 
         dc : obj)
        ([<ExcelArgument(Name="comp",Description = "Reference to comp")>] 
         comp : obj)
        ([<ExcelArgument(Name="freq",Description = "Reference to freq")>] 
         freq : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".Yield") 
                                               [| _CPIBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _dc.cell
                                ;  _comp.cell
                                ;  _freq.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
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
    [<ExcelFunction(Name="_CPIBond_CASH", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".CASH") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_errorEstimate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".ErrorEstimate") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_NPV", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".NPV") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
        returns any additional result returned by the pricing engine.
    *)
    [<ExcelFunction(Name="_CPIBond_result", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".Result") 
                                               [| _CPIBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _tag.cell
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
        ! calling this method will have no effects in case the performCalculation method was overridden in a derived class.
    *)
    [<ExcelFunction(Name="_CPIBond_setPricingEngine", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CPIBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".SetPricingEngine") 
                                               [| _CPIBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
                                ;  _e.cell
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
        ! returns the date the net present value refers to.
    *)
    [<ExcelFunction(Name="_CPIBond_valuationDate", Description="Create a CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CPIBond",Description = "Reference to CPIBond")>] 
         cpibond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CPIBond = Helper.toCell<CPIBond> cpibond "CPIBond"  
                let builder () = withMnemonic mnemonic ((_CPIBond.cell :?> CPIBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CPIBond.source + ".ValuationDate") 
                                               [| _CPIBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CPIBond.cell
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
    [<ExcelFunction(Name="_CPIBond_Range", Description="Create a range of CPIBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CPIBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CPIBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CPIBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CPIBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CPIBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CPIBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
