(*
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
  Base class for options on a single asset

  </summary> *)
[<AutoSerializable(true)>]
type OneAssetOptionModel
    ( payoff                                       : ICell<Payoff>
    , exercise                                     : ICell<Exercise>
    , pricingEngine                                : ICell<IPricingEngine>
    , evaluationDate                               : ICell<Date>
    ) as this =

    inherit Model<OneAssetOption> ()
(*
    Parameters
*)
    let _payoff                                    = payoff
    let _exercise                                  = exercise
    let _evaluationDate                            = evaluationDate
    let _pricingEngine                             = pricingEngine
(*
    Functions
*)
    let _OneAssetOption                            = cell (fun () -> withEngine _pricingEngine.Value (new OneAssetOption (payoff.Value, exercise.Value)))
    let _delta                                     = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).delta())
    let _deltaForward                              = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).deltaForward())
    let _dividendRho                               = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).dividendRho())
    let _elasticity                                = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).elasticity())
    let _gamma                                     = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).gamma())
    let _isExpired                                 = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).isExpired())
    let _itmCashProbability                        = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).itmCashProbability())
    let _rho                                       = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).rho())
    let _strikeSensitivity                         = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).strikeSensitivity())
    let _theta                                     = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).theta())
    let _thetaPerDay                               = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).thetaPerDay())
    let _vega                                      = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).vega())
    let _exercise                                  = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).exercise())
    let _payoff                                    = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).payoff())
    let _CASH                                      = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).CASH())
    let _errorEstimate                             = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).errorEstimate())
    let _NPV                                       = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).NPV())
    let _result                                    (tag : ICell<string>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).result(tag.Value))
    let _setPricingEngine                          (e : ICell<IPricingEngine>)   
                                                   = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).setPricingEngine(e.Value)
                                                                     _OneAssetOption.Value)
    let _valuationDate                             = cell (fun () -> (withEvaluationDate _evaluationDate _OneAssetOption).valuationDate())
    do this.Bind(_OneAssetOption)

(* 
    Externally visible/bindable properties
*)
    member this.payoff                             = _payoff 
    member this.exercise                           = _exercise 
    member this.EvaluationDate                     = _evaluationDate
    member this.PricingEngine                      = _pricingEngine
    member this.Delta                              = _delta
    member this.DeltaForward                       = _deltaForward
    member this.DividendRho                        = _dividendRho
    member this.Elasticity                         = _elasticity
    member this.Gamma                              = _gamma
    member this.IsExpired                          = _isExpired
    member this.ItmCashProbability                 = _itmCashProbability
    member this.Rho                                = _rho
    member this.StrikeSensitivity                  = _strikeSensitivity
    member this.Theta                              = _theta
    member this.ThetaPerDay                        = _thetaPerDay
    member this.Vega                               = _vega
    member this.Exercise                           = _exercise
    member this.Payoff                             = _payoff
    member this.CASH                               = _CASH
    member this.ErrorEstimate                      = _errorEstimate
    member this.NPV                                = _NPV
    member this.Result                             tag   
                                                   = _result tag 
    member this.SetPricingEngine                   e   
                                                   = _setPricingEngine e 
    member this.ValuationDate                      = _valuationDate