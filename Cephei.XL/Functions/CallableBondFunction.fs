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
(*!!
(* <summary>

  </summary> *)
[<AutoSerializable(true)>]
module CallableBondFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_CallableBond_callability", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_callability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Callability
                                                       ) :> ICell
                let format (o : CallabilitySchedule) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".Callability") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_cleanPriceOAS", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_cleanPriceOAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).CleanPriceOAS
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".CleanPriceOAS") 
                                               [| _CallableBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
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
    [<ExcelFunction(Name="_CallableBond_effectiveConvexity", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_effectiveConvexity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "Reference to bump")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toCell<double> bump "bump" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).EffectiveConvexity
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".EffectiveConvexity") 
                                               [| _CallableBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
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
    [<ExcelFunction(Name="_CallableBond_effectiveDuration", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_effectiveDuration
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="oas",Description = "Reference to oas")>] 
         oas : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="bump",Description = "Reference to bump")>] 
         bump : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _oas = Helper.toCell<double> oas "oas" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _bump = Helper.toCell<double> bump "bump" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).EffectiveDuration
                                                            _oas.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _bump.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".EffectiveDuration") 
                                               [| _CallableBond.source
                                               ;  _oas.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _bump.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                ;  _oas.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _bump.cell
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
    [<ExcelFunction(Name="_CallableBond_impliedVolatility", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_impliedVolatility
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="targetValue",Description = "Reference to targetValue")>] 
         targetValue : obj)
        ([<ExcelArgument(Name="discountCurve",Description = "Reference to discountCurve")>] 
         discountCurve : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxEvaluations",Description = "Reference to maxEvaluations")>] 
         maxEvaluations : obj)
        ([<ExcelArgument(Name="minVol",Description = "Reference to minVol")>] 
         minVol : obj)
        ([<ExcelArgument(Name="maxVol",Description = "Reference to maxVol")>] 
         maxVol : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _targetValue = Helper.toCell<double> targetValue "targetValue" 
                let _discountCurve = Helper.toHandle<YieldTermStructure> discountCurve "discountCurve" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let _minVol = Helper.toCell<double> minVol "minVol" 
                let _maxVol = Helper.toCell<double> maxVol "maxVol" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).ImpliedVolatility
                                                            _targetValue.cell 
                                                            _discountCurve.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                            _minVol.cell 
                                                            _maxVol.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".ImpliedVolatility") 
                                               [| _CallableBond.source
                                               ;  _targetValue.source
                                               ;  _discountCurve.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               ;  _minVol.source
                                               ;  _maxVol.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                ;  _targetValue.cell
                                ;  _discountCurve.cell
                                ;  _accuracy.cell
                                ;  _maxEvaluations.cell
                                ;  _minVol.cell
                                ;  _maxVol.cell
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
    [<ExcelFunction(Name="_CallableBond_OAS", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_OAS
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        ([<ExcelArgument(Name="engineTS",Description = "Reference to engineTS")>] 
         engineTS : obj)
        ([<ExcelArgument(Name="dayCounter",Description = "Reference to dayCounter")>] 
         dayCounter : obj)
        ([<ExcelArgument(Name="compounding",Description = "Reference to compounding")>] 
         compounding : obj)
        ([<ExcelArgument(Name="frequency",Description = "Reference to frequency")>] 
         frequency : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        ([<ExcelArgument(Name="accuracy",Description = "Reference to accuracy")>] 
         accuracy : obj)
        ([<ExcelArgument(Name="maxIterations",Description = "Reference to maxIterations")>] 
         maxIterations : obj)
        ([<ExcelArgument(Name="guess",Description = "Reference to guess")>] 
         guess : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _engineTS = Helper.toHandle<YieldTermStructure> engineTS "engineTS" 
                let _dayCounter = Helper.toCell<DayCounter> dayCounter "dayCounter" 
                let _compounding = Helper.toCell<Compounding> compounding "compounding" 
                let _frequency = Helper.toCell<Frequency> frequency "frequency" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxIterations = Helper.toCell<int> maxIterations "maxIterations" 
                let _guess = Helper.toCell<double> guess "guess" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).OAS
                                                            _cleanPrice.cell 
                                                            _engineTS.cell 
                                                            _dayCounter.cell 
                                                            _compounding.cell 
                                                            _frequency.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxIterations.cell 
                                                            _guess.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".OAS") 
                                               [| _CallableBond.source
                                               ;  _cleanPrice.source
                                               ;  _engineTS.source
                                               ;  _dayCounter.source
                                               ;  _compounding.source
                                               ;  _frequency.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxIterations.source
                                               ;  _guess.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                ;  _cleanPrice.cell
                                ;  _engineTS.cell
                                ;  _dayCounter.cell
                                ;  _compounding.cell
                                ;  _frequency.cell
                                ;  _settlement.cell
                                ;  _accuracy.cell
                                ;  _maxIterations.cell
                                ;  _guess.cell
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
    [<ExcelFunction(Name="_CallableBond_accruedAmount", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_accruedAmount
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).AccruedAmount
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".AccruedAmount") 
                                               [| _CallableBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_calendar", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_calendar
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Calendar
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Calendar>) l

                let source = Helper.sourceFold (_CallableBond.source + ".Calendar") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBond> format
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
    [<ExcelFunction(Name="_CallableBond_cashflows", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_cashflows
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Cashflows
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CallableBond.source + ".Cashflows") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_cleanPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).CleanPrice
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".CleanPrice") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_cleanPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_cleanPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
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

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).CleanPrice1
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".CleanPrice") 
                                               [| _CallableBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_dirtyPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
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

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _Yield = Helper.toCell<double> Yield "Yield" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).DirtyPrice
                                                            _Yield.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".DirtyPrice") 
                                               [| _CallableBond.source
                                               ;  _Yield.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_dirtyPrice", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_dirtyPrice
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).DirtyPrice1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".DirtyPrice") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_isExpired", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".IsExpired") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_issueDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_issueDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).IssueDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".IssueDate") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_isTradable", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_isTradable
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).IsTradable
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".IsTradable") 
                                               [| _CallableBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_maturityDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_maturityDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).MaturityDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".MaturityDate") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_nextCashFlowDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_nextCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).NextCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".NextCashFlowDate") 
                                               [| _CallableBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_nextCouponRate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_nextCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).NextCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".NextCouponRate") 
                                               [| _CallableBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_notional", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_notional
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="d",Description = "Reference to d")>] 
         d : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _d = Helper.toCell<Date> d "d" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Notional
                                                            _d.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".Notional") 
                                               [| _CallableBond.source
                                               ;  _d.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_notionals", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_notionals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Notionals
                                                       ) :> ICell
                let format (i : Generic.List<double>) (l : string) = (Helper.Range.fromArray (i.ToArray()) l)

                let source = Helper.sourceFold (_CallableBond.source + ".Notionals") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_previousCashFlowDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_previousCashFlowDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).PreviousCashFlowDate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".PreviousCashFlowDate") 
                                               [| _CallableBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_previousCouponRate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_previousCouponRate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="settlement",Description = "Reference to settlement")>] 
         settlement : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).PreviousCouponRate
                                                            _settlement.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".PreviousCouponRate") 
                                               [| _CallableBond.source
                                               ;  _settlement.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_redemption", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_redemption
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Redemption
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<CashFlow>) l

                let source = Helper.sourceFold (_CallableBond.source + ".Redemption") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<CallableBond> format
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
    [<ExcelFunction(Name="_CallableBond_redemptions", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_redemptions
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Redemptions
                                                       ) :> ICell
                let format (i : Generic.List<ICell<CashFlow>>) (l : string) = Helper.Range.fromModelList i l

                let source = Helper.sourceFold (_CallableBond.source + ".Redemptions") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_settlementDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="date",Description = "Reference to date")>] 
         date : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _date = Helper.toCell<Date> date "date" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).SettlementDate
                                                            _date.cell 
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".SettlementDate") 
                                               [| _CallableBond.source
                                               ;  _date.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementDays", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_settlementDays
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).SettlementDays
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".SettlementDays") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementValue", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="cleanPrice",Description = "Reference to cleanPrice")>] 
         cleanPrice : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).SettlementValue
                                                            _cleanPrice.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".SettlementValue") 
                                               [| _CallableBond.source
                                               ;  _cleanPrice.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_settlementValue", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_settlementValue
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).SettlementValue1
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".SettlementValue") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_startDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_startDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).StartDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".StartDate") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_yield", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
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

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _cleanPrice = Helper.toCell<double> cleanPrice "cleanPrice" 
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _settlement = Helper.toCell<Date> settlement "settlement" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Yield
                                                            _cleanPrice.cell 
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _settlement.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".Yield") 
                                               [| _CallableBond.source
                                               ;  _cleanPrice.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _settlement.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_yield", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_yield
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
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

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _dc = Helper.toCell<DayCounter> dc "dc" 
                let _comp = Helper.toCell<Compounding> comp "comp" 
                let _freq = Helper.toCell<Frequency> freq "freq" 
                let _accuracy = Helper.toCell<double> accuracy "accuracy" 
                let _maxEvaluations = Helper.toCell<int> maxEvaluations "maxEvaluations" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Yield1
                                                            _dc.cell 
                                                            _comp.cell 
                                                            _freq.cell 
                                                            _accuracy.cell 
                                                            _maxEvaluations.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".Yield") 
                                               [| _CallableBond.source
                                               ;  _dc.source
                                               ;  _comp.source
                                               ;  _freq.source
                                               ;  _accuracy.source
                                               ;  _maxEvaluations.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_CASH", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".CASH") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_errorEstimate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".ErrorEstimate") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_NPV", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".NPV") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_result", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".Result") 
                                               [| _CallableBond.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_setPricingEngine", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : CallableBond) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".SetPricingEngine") 
                                               [| _CallableBond.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_valuationDate", Description="Create a CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="CallableBond",Description = "Reference to CallableBond")>] 
         callablebond : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _CallableBond = Helper.toCell<CallableBond> callablebond "CallableBond"  
                let builder () = withMnemonic mnemonic ((_CallableBond.cell :?> CallableBondModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_CallableBond.source + ".ValuationDate") 
                                               [| _CallableBond.source
                                               |]
                let hash = Helper.hashFold 
                                [| _CallableBond.cell
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
    [<ExcelFunction(Name="_CallableBond_Range", Description="Create a range of CallableBond",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let CallableBond_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the CallableBond")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<CallableBond> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<CallableBond>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<CallableBond>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<CallableBond>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
*)
