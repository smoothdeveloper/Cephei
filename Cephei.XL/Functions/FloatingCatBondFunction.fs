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

  </summary> *)
[<AutoSerializable(true)>]
module FloatingCatBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_FloatingCatBond", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="maturityDate",Description = "Reference to maturityDate")>] 
         maturityDate : obj)
        ([<ExcelArgument(Name="couponFrequency",Description = "Reference to couponFrequency")>] 
         couponFrequency : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="notionalRisk",Description = "Reference to notionalRisk")>] 
         notionalRisk : obj)
        ([<ExcelArgument(Name="accrualConvention",Description = "Reference to accrualConvention")>] 
         accrualConvention : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "Reference to caps")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "Reference to inArrears")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="stubDate",Description = "Reference to stubDate")>] 
         stubDate : obj)
        ([<ExcelArgument(Name="rule",Description = "Reference to rule")>] 
         rule : obj)
        ([<ExcelArgument(Name="endOfMonth",Description = "Reference to endOfMonth")>] 
         endOfMonth : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _maturityDate = Helper.toCell<Date> maturityDate "maturityDate" 
                let _couponFrequency = Helper.toCell<Frequency> couponFrequency "couponFrequency" 
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _notionalRisk = Helper.toCell<NotionalRisk> notionalRisk "notionalRisk" 
                let _accrualConvention = Helper.toCell<BusinessDayConvention> accrualConvention "accrualConvention" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let _caps = Helper.toCell<Generic.List<Nullable<double>>> caps "caps" 
                let _floors = Helper.toCell<Generic.List<Nullable<double>>> floors "floors" 
                let _inArrears = Helper.toCell<bool> inArrears "inArrears" 
                let _redemption = Helper.toCell<double> redemption "redemption" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _stubDate = Helper.toCell<Date> stubDate "stubDate" 
                let _rule = Helper.toCell<DateGeneration.Rule> rule "rule" 
                let _endOfMonth = Helper.toCell<bool> endOfMonth "endOfMonth" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.FloatingCatBond 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _startDate.cell 
                                                            _maturityDate.cell 
                                                            _couponFrequency.cell 
                                                            _calendar.cell 
                                                            _iborIndex.cell 
                                                            _accrualDayCounter.cell 
                                                            _notionalRisk.cell 
                                                            _accrualConvention.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _caps.cell 
                                                            _floors.cell 
                                                            _inArrears.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _stubDate.cell 
                                                            _rule.cell 
                                                            _endOfMonth.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingCatBond>) l

                let source = Helper.sourceFold "Fun.FloatingCatBond" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _startDate.source
                                               ;  _maturityDate.source
                                               ;  _couponFrequency.source
                                               ;  _calendar.source
                                               ;  _iborIndex.source
                                               ;  _accrualDayCounter.source
                                               ;  _notionalRisk.source
                                               ;  _accrualConvention.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _caps.source
                                               ;  _floors.source
                                               ;  _inArrears.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _stubDate.source
                                               ;  _rule.source
                                               ;  _endOfMonth.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _startDate.cell
                                ;  _maturityDate.cell
                                ;  _couponFrequency.cell
                                ;  _calendar.cell
                                ;  _iborIndex.cell
                                ;  _accrualDayCounter.cell
                                ;  _notionalRisk.cell
                                ;  _accrualConvention.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _caps.cell
                                ;  _floors.cell
                                ;  _inArrears.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _stubDate.cell
                                ;  _rule.cell
                                ;  _endOfMonth.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingCatBond1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_create1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="schedule",Description = "Reference to schedule")>] 
         schedule : obj)
        ([<ExcelArgument(Name="iborIndex",Description = "Reference to iborIndex")>] 
         iborIndex : obj)
        ([<ExcelArgument(Name="paymentDayCounter",Description = "Reference to paymentDayCounter")>] 
         paymentDayCounter : obj)
        ([<ExcelArgument(Name="notionalRisk",Description = "Reference to notionalRisk")>] 
         notionalRisk : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
        ([<ExcelArgument(Name="fixingDays",Description = "Reference to fixingDays")>] 
         fixingDays : obj)
        ([<ExcelArgument(Name="gearings",Description = "Reference to gearings")>] 
         gearings : obj)
        ([<ExcelArgument(Name="spreads",Description = "Reference to spreads")>] 
         spreads : obj)
        ([<ExcelArgument(Name="caps",Description = "Reference to caps")>] 
         caps : obj)
        ([<ExcelArgument(Name="floors",Description = "Reference to floors")>] 
         floors : obj)
        ([<ExcelArgument(Name="inArrears",Description = "Reference to inArrears")>] 
         inArrears : obj)
        ([<ExcelArgument(Name="redemption",Description = "Reference to redemption")>] 
         redemption : obj)
        ([<ExcelArgument(Name="issueDate",Description = "Reference to issueDate")>] 
         issueDate : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _settlementDays = Helper.toCell<int> settlementDays "settlementDays" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _schedule = Helper.toCell<Schedule> schedule "schedule" 
                let _iborIndex = Helper.toCell<IborIndex> iborIndex "iborIndex" 
                let _paymentDayCounter = Helper.toCell<DayCounter> paymentDayCounter "paymentDayCounter" 
                let _notionalRisk = Helper.toCell<NotionalRisk> notionalRisk "notionalRisk" 
                let _paymentConvention = Helper.toCell<BusinessDayConvention> paymentConvention "paymentConvention" 
                let _fixingDays = Helper.toCell<int> fixingDays "fixingDays" 
                let _gearings = Helper.toCell<Generic.List<double>> gearings "gearings" 
                let _spreads = Helper.toCell<Generic.List<double>> spreads "spreads" 
                let _caps = Helper.toCell<Generic.List<Nullable<double>>> caps "caps" 
                let _floors = Helper.toCell<Generic.List<Nullable<double>>> floors "floors" 
                let _inArrears = Helper.toCell<bool> inArrears "inArrears" 
                let _redemption = Helper.toCell<double> redemption "redemption" 
                let _issueDate = Helper.toCell<Date> issueDate "issueDate" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.FloatingCatBond1 
                                                            _settlementDays.cell 
                                                            _faceAmount.cell 
                                                            _schedule.cell 
                                                            _iborIndex.cell 
                                                            _paymentDayCounter.cell 
                                                            _notionalRisk.cell 
                                                            _paymentConvention.cell 
                                                            _fixingDays.cell 
                                                            _gearings.cell 
                                                            _spreads.cell 
                                                            _caps.cell 
                                                            _floors.cell 
                                                            _inArrears.cell 
                                                            _redemption.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<FloatingCatBond>) l

                let source = Helper.sourceFold "Fun.FloatingCatBond1" 
                                               [| _settlementDays.source
                                               ;  _faceAmount.source
                                               ;  _schedule.source
                                               ;  _iborIndex.source
                                               ;  _paymentDayCounter.source
                                               ;  _notionalRisk.source
                                               ;  _paymentConvention.source
                                               ;  _fixingDays.source
                                               ;  _gearings.source
                                               ;  _spreads.source
                                               ;  _caps.source
                                               ;  _floors.source
                                               ;  _inArrears.source
                                               ;  _redemption.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _faceAmount.cell
                                ;  _schedule.cell
                                ;  _iborIndex.cell
                                ;  _paymentDayCounter.cell
                                ;  _notionalRisk.cell
                                ;  _paymentConvention.cell
                                ;  _fixingDays.cell
                                ;  _gearings.cell
                                ;  _spreads.cell
                                ;  _caps.cell
                                ;  _floors.cell
                                ;  _inArrears.cell
                                ;  _redemption.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_FloatingCatBond_exhaustionProbability", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_exhaustionProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).ExhaustionProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".ExhaustionProbability") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_expectedLoss", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_expectedLoss
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).ExpectedLoss
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".ExpectedLoss") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_lossProbability", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_lossProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).LossProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".LossProbability") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_accruedAmount", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".AccruedAmount") 
                                               [| _FloatingCatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_calendar", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Calendar") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
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
    [<ExcelFunction(Name="_FloatingCatBond_cashflows", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Cashflows") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_cleanPrice", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".CleanPrice") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_cleanPrice1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".CleanPrice1") 
                                               [| _FloatingCatBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_dirtyPrice1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".DirtyPrice1") 
                                               [| _FloatingCatBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_dirtyPrice", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".DirtyPrice") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_isExpired", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".IsExpired") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_issueDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".IssueDate") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_isTradable", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".IsTradable") 
                                               [| _FloatingCatBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_maturityDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".MaturityDate") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_nextCashFlowDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".NextCashFlowDate") 
                                               [| _FloatingCatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_nextCouponRate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".NextCouponRate") 
                                               [| _FloatingCatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_notional", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Notional") 
                                               [| _FloatingCatBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_notionals", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Notionals") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_previousCashFlowDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".PreviousCashFlowDate") 
                                               [| _FloatingCatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_previousCouponRate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".PreviousCouponRate") 
                                               [| _FloatingCatBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_redemption", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Redemption") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<FloatingCatBond> format
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
    [<ExcelFunction(Name="_FloatingCatBond_redemptions", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Redemptions") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".SettlementDate") 
                                               [| _FloatingCatBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementDays", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".SettlementDays") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementValue", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".SettlementValue") 
                                               [| _FloatingCatBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_settlementValue1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".SettlementValue1") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_startDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".StartDate") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_yield1", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Yield1") 
                                               [| _FloatingCatBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_yield", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
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

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Yield") 
                                               [| _FloatingCatBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_CASH", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".CASH") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_errorEstimate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".ErrorEstimate") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_NPV", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".NPV") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_result", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".Result") 
                                               [| _FloatingCatBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_setPricingEngine", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : FloatingCatBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".SetPricingEngine") 
                                               [| _FloatingCatBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_valuationDate", Description="Create a FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="FloatingCatBond",Description = "Reference to FloatingCatBond")>] 
         floatingcatbond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _FloatingCatBond = Helper.toCell<FloatingCatBond> floatingcatbond "FloatingCatBond"  
                let builder () = withMnemonic mnemonic ((_FloatingCatBond.cell :?> FloatingCatBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_FloatingCatBond.source + ".ValuationDate") 
                                               [| _FloatingCatBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _FloatingCatBond.cell
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
    [<ExcelFunction(Name="_FloatingCatBond_Range", Description="Create a range of FloatingCatBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let FloatingCatBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the FloatingCatBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<FloatingCatBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<FloatingCatBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<FloatingCatBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<FloatingCatBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
