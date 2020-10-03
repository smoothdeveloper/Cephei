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
  When the variance is null, division by zero occur during the calculation of delta, delta forward, gamma, gamma forward, rho, dividend rho, vega, and strike sensitivity.
  </summary> *)
[<AutoSerializable(true)>]
module BlackCalculatorFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BlackCalculator_alpha", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_alpha
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Alpha
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Alpha") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
    [<ExcelFunction(Name="_BlackCalculator_beta", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_beta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Beta
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Beta") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
    [<ExcelFunction(Name="_BlackCalculator", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="payoff",Description = "Reference to payoff")>] 
         payoff : obj)
        ([<ExcelArgument(Name="forward",Description = "Reference to forward")>] 
         forward : obj)
        ([<ExcelArgument(Name="stdDev",Description = "Reference to stdDev")>] 
         stdDev : obj)
        ([<ExcelArgument(Name="discount",Description = "Reference to discount")>] 
         discount : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _payoff = Helper.toCell<StrikedTypePayoff> payoff "payoff" 
                let _forward = Helper.toCell<double> forward "forward" 
                let _stdDev = Helper.toCell<double> stdDev "stdDev" 
                let _discount = Helper.toCell<double> discount "discount" 
                let builder () = withMnemonic mnemonic (Fun.BlackCalculator 
                                                            _payoff.cell 
                                                            _forward.cell 
                                                            _stdDev.cell 
                                                            _discount.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BlackCalculator>) l

                let source = Helper.sourceFold "Fun.BlackCalculator" 
                                               [| _payoff.source
                                               ;  _forward.source
                                               ;  _stdDev.source
                                               ;  _discount.source
                                               |]
                let hash = Helper.hashFold 
                                [| _payoff.cell
                                ;  _forward.cell
                                ;  _stdDev.cell
                                ;  _discount.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BlackCalculator> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! Sensitivity to change in the underlying spot price.
    *)
    [<ExcelFunction(Name="_BlackCalculator_delta", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_delta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _spot = Helper.toCell<double> spot "spot" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Delta
                                                            _spot.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Delta") 
                                               [| _BlackCalculator.source
                                               ;  _spot.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _spot.cell
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
        ! Sensitivity to change in the underlying forward price.
    *)
    [<ExcelFunction(Name="_BlackCalculator_deltaForward", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_deltaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).DeltaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".DeltaForward") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
        ! Sensitivity to dividend/growth rate.
    *)
    [<ExcelFunction(Name="_BlackCalculator_dividendRho", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_dividendRho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).DividendRho
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".DividendRho") 
                                               [| _BlackCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _maturity.cell
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
        ! Sensitivity in percent to a percent change in the underlying spot price.
    *)
    [<ExcelFunction(Name="_BlackCalculator_elasticity", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_elasticity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _spot = Helper.toCell<double> spot "spot" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Elasticity
                                                            _spot.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Elasticity") 
                                               [| _BlackCalculator.source
                                               ;  _spot.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _spot.cell
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
        ! Sensitivity in percent to a percent change in the underlying forward price.
    *)
    [<ExcelFunction(Name="_BlackCalculator_elasticityForward", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_elasticityForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).ElasticityForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".ElasticityForward") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
        ! Second order derivative with respect to change in the underlying spot price.
    *)
    [<ExcelFunction(Name="_BlackCalculator_gamma", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_gamma
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _spot = Helper.toCell<double> spot "spot" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Gamma
                                                            _spot.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Gamma") 
                                               [| _BlackCalculator.source
                                               ;  _spot.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _spot.cell
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
        ! Second order derivative with respect to change in the underlying forward price.
    *)
    [<ExcelFunction(Name="_BlackCalculator_gammaForward", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_gammaForward
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).GammaForward
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".GammaForward") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
        ! Probability of being in the money in the asset martingale measure, i.e. N(d1). It is a risk-neutral probability, not the real world one.
    *)
    [<ExcelFunction(Name="_BlackCalculator_itmAssetProbability", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_itmAssetProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).ItmAssetProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".ItmAssetProbability") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
        ! Probability of being in the money in the bond martingale measure, i.e. N(d2). It is a risk-neutral probability, not the real world one.
    *)
    [<ExcelFunction(Name="_BlackCalculator_itmCashProbability", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_itmCashProbability
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).ItmCashProbability
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".ItmCashProbability") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
        ! Sensitivity to discounting rate.
    *)
    [<ExcelFunction(Name="_BlackCalculator_rho", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_rho
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Rho
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Rho") 
                                               [| _BlackCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _maturity.cell
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
        ! Sensitivity to strike.
    *)
    [<ExcelFunction(Name="_BlackCalculator_strikeSensitivity", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_strikeSensitivity
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).StrikeSensitivity
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".StrikeSensitivity") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
        ! Sensitivity to time to maturity.
    *)
    [<ExcelFunction(Name="_BlackCalculator_theta", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_theta
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _spot = Helper.toCell<double> spot "spot" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Theta
                                                            _spot.cell 
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Theta") 
                                               [| _BlackCalculator.source
                                               ;  _spot.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _spot.cell
                                ;  _maturity.cell
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
        ! Sensitivity to time to maturity per day, assuming 365 day per year.
    *)
    [<ExcelFunction(Name="_BlackCalculator_thetaPerDay", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_thetaPerDay
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="spot",Description = "Reference to spot")>] 
         spot : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _spot = Helper.toCell<double> spot "spot" 
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).ThetaPerDay
                                                            _spot.cell 
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".ThetaPerDay") 
                                               [| _BlackCalculator.source
                                               ;  _spot.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _spot.cell
                                ;  _maturity.cell
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
    [<ExcelFunction(Name="_BlackCalculator_value", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_value
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Value
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Value") 
                                               [| _BlackCalculator.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
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
        ! Sensitivity to volatility.
    *)
    [<ExcelFunction(Name="_BlackCalculator_vega", Description="Create a BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_vega
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BlackCalculator",Description = "Reference to BlackCalculator")>] 
         blackcalculator : obj)
        ([<ExcelArgument(Name="maturity",Description = "Reference to maturity")>] 
         maturity : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BlackCalculator = Helper.toCell<BlackCalculator> blackcalculator "BlackCalculator"  
                let _maturity = Helper.toCell<double> maturity "maturity" 
                let builder () = withMnemonic mnemonic ((_BlackCalculator.cell :?> BlackCalculatorModel).Vega
                                                            _maturity.cell 
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_BlackCalculator.source + ".Vega") 
                                               [| _BlackCalculator.source
                                               ;  _maturity.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BlackCalculator.cell
                                ;  _maturity.cell
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
    [<ExcelFunction(Name="_BlackCalculator_Range", Description="Create a range of BlackCalculator",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BlackCalculator_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BlackCalculator")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BlackCalculator> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BlackCalculator>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BlackCalculator>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BlackCalculator>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"