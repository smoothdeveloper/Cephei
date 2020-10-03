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
module MBSFixedRateBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MBSFixedRateBond_BondEquivalentYield", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_BondEquivalentYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).BondEquivalentYield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".BondEquivalentYield") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_BondFactors", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_BondFactors
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).BondFactors
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".BondFactors") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_expectedCashflows", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_expectedCashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).ExpectedCashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".ExpectedCashflows") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="settlementDays",Description = "Reference to settlementDays")>] 
         settlementDays : obj)
        ([<ExcelArgument(Name="calendar",Description = "Reference to calendar")>] 
         calendar : obj)
        ([<ExcelArgument(Name="faceAmount",Description = "Reference to faceAmount")>] 
         faceAmount : obj)
        ([<ExcelArgument(Name="startDate",Description = "Reference to startDate")>] 
         startDate : obj)
        ([<ExcelArgument(Name="bondTenor",Description = "Reference to bondTenor")>] 
         bondTenor : obj)
        ([<ExcelArgument(Name="originalLength",Description = "Reference to originalLength")>] 
         originalLength : obj)
        ([<ExcelArgument(Name="sinkingFrequency",Description = "Reference to sinkingFrequency")>] 
         sinkingFrequency : obj)
        ([<ExcelArgument(Name="WACRate",Description = "Reference to WACRate")>] 
         WACRate : obj)
        ([<ExcelArgument(Name="PassThroughRate",Description = "Reference to PassThroughRate")>] 
         PassThroughRate : obj)
        ([<ExcelArgument(Name="accrualDayCounter",Description = "Reference to accrualDayCounter")>] 
         accrualDayCounter : obj)
        ([<ExcelArgument(Name="prepayModel",Description = "Reference to prepayModel")>] 
         prepayModel : obj)
        ([<ExcelArgument(Name="paymentConvention",Description = "Reference to paymentConvention")>] 
         paymentConvention : obj)
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
                let _calendar = Helper.toCell<Calendar> calendar "calendar" 
                let _faceAmount = Helper.toCell<double> faceAmount "faceAmount" 
                let _startDate = Helper.toCell<Date> startDate "startDate" 
                let _bondTenor = Helper.toCell<Period> bondTenor "bondTenor" 
                let _originalLength = Helper.toCell<Period> originalLength "originalLength" 
                let _sinkingFrequency = Helper.toCell<Frequency> sinkingFrequency "sinkingFrequency" 
                let _WACRate = Helper.toCell<double> WACRate "WACRate" 
                let _PassThroughRate = Helper.toCell<double> PassThroughRate "PassThroughRate" 
                let _accrualDayCounter = Helper.toCell<DayCounter> accrualDayCounter "accrualDayCounter" 
                let _prepayModel = Helper.toCell<IPrepayModel> prepayModel "prepayModel" 
                let _paymentConvention = Helper.toDefault<BusinessDayConvention> paymentConvention "paymentConvention" BusinessDayConvention.Following
                let _issueDate = Helper.toDefault<Date> issueDate "issueDate" null
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.MBSFixedRateBond 
                                                            _settlementDays.cell 
                                                            _calendar.cell 
                                                            _faceAmount.cell 
                                                            _startDate.cell 
                                                            _bondTenor.cell 
                                                            _originalLength.cell 
                                                            _sinkingFrequency.cell 
                                                            _WACRate.cell 
                                                            _PassThroughRate.cell 
                                                            _accrualDayCounter.cell 
                                                            _prepayModel.cell 
                                                            _paymentConvention.cell 
                                                            _issueDate.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MBSFixedRateBond>) l

                let source = Helper.sourceFold "Fun.MBSFixedRateBond" 
                                               [| _settlementDays.source
                                               ;  _calendar.source
                                               ;  _faceAmount.source
                                               ;  _startDate.source
                                               ;  _bondTenor.source
                                               ;  _originalLength.source
                                               ;  _sinkingFrequency.source
                                               ;  _WACRate.source
                                               ;  _PassThroughRate.source
                                               ;  _accrualDayCounter.source
                                               ;  _prepayModel.source
                                               ;  _paymentConvention.source
                                               ;  _issueDate.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _settlementDays.cell
                                ;  _calendar.cell
                                ;  _faceAmount.cell
                                ;  _startDate.cell
                                ;  _bondTenor.cell
                                ;  _originalLength.cell
                                ;  _sinkingFrequency.cell
                                ;  _WACRate.cell
                                ;  _PassThroughRate.cell
                                ;  _accrualDayCounter.cell
                                ;  _prepayModel.cell
                                ;  _paymentConvention.cell
                                ;  _issueDate.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MBSFixedRateBond_MonthlyYield", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_MonthlyYield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).MonthlyYield
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".MonthlyYield") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_SMM", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_SMM
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).SMM
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".SMM") 
                                               [| _MBSFixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_dayCounter", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_dayCounter
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).DayCounter
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<DayCounter>) l

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".DayCounter") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_MBSFixedRateBond_frequency", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_frequency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Frequency
                                                       ) :> ICell
                let format (o : Frequency) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Frequency") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_accruedAmount", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".AccruedAmount") 
                                               [| _MBSFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_calendar", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Calendar") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
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
    [<ExcelFunction(Name="_MBSFixedRateBond_cashflows", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Cashflows") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_cleanPrice", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".CleanPrice") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_cleanPrice1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_cleanPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".CleanPrice1") 
                                               [| _MBSFixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_dirtyPrice1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_dirtyPrice1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).DirtyPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".DirtyPrice1") 
                                               [| _MBSFixedRateBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_dirtyPrice", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).DirtyPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".DirtyPrice") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_isExpired", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".IsExpired") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_issueDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".IssueDate") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_isTradable", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".IsTradable") 
                                               [| _MBSFixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_maturityDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".MaturityDate") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_nextCashFlowDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".NextCashFlowDate") 
                                               [| _MBSFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_nextCouponRate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".NextCouponRate") 
                                               [| _MBSFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_notional", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Notional") 
                                               [| _MBSFixedRateBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_notionals", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Notionals") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_previousCashFlowDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".PreviousCashFlowDate") 
                                               [| _MBSFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_previousCouponRate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".PreviousCouponRate") 
                                               [| _MBSFixedRateBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_redemption", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Redemption") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MBSFixedRateBond> format
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
    [<ExcelFunction(Name="_MBSFixedRateBond_redemptions", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Redemptions") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementDate") 
                                               [| _MBSFixedRateBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementDays", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementDays") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementValue", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementValue") 
                                               [| _MBSFixedRateBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_settlementValue1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_settlementValue1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".SettlementValue1") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_startDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".StartDate") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_yield1", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_yield1
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Yield1
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Yield1") 
                                               [| _MBSFixedRateBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_yield", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
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

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Yield
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Yield") 
                                               [| _MBSFixedRateBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_CASH", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".CASH") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_errorEstimate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".ErrorEstimate") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_NPV", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".NPV") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_result", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".Result") 
                                               [| _MBSFixedRateBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_setPricingEngine", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : MBSFixedRateBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".SetPricingEngine") 
                                               [| _MBSFixedRateBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_valuationDate", Description="Create a MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MBSFixedRateBond",Description = "Reference to MBSFixedRateBond")>] 
         mbsfixedratebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MBSFixedRateBond = Helper.toCell<MBSFixedRateBond> mbsfixedratebond "MBSFixedRateBond"  
                let builder () = withMnemonic mnemonic ((_MBSFixedRateBond.cell :?> MBSFixedRateBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_MBSFixedRateBond.source + ".ValuationDate") 
                                               [| _MBSFixedRateBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MBSFixedRateBond.cell
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
    [<ExcelFunction(Name="_MBSFixedRateBond_Range", Description="Create a range of MBSFixedRateBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MBSFixedRateBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MBSFixedRateBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MBSFixedRateBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MBSFixedRateBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MBSFixedRateBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MBSFixedRateBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
