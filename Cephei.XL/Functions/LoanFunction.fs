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
module LoanFunction =

    (*
        Instrument interface
    *)
    [<ExcelFunction(Name="_Loan_isExpired", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_isExpired
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Loan",Description = "Reference to Loan")>] 
         loan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Loan = Helper.toCell<Loan> loan "Loan"  
                let builder () = withMnemonic mnemonic ((_Loan.cell :?> LoanModel).IsExpired
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Loan.source + ".IsExpired") 
                                               [| _Loan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Loan.cell
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
    [<ExcelFunction(Name="_Loan", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="legs",Description = "Reference to legs")>] 
         legs : obj)
        ([<ExcelArgument(Name="pricingEngine",Description = "Reference to Pricing Engine used")>] 
         pricingEngine : obj)
        ([<ExcelArgument(Name="evaluationDate",Description = "Reference to the date used for evaluation")>] 
         evaluationDate : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _legs = Helper.toCell<int> legs "legs" 
                let _pricingEngine = Helper.toCell<IPricingEngine> pricingEngine "pricingEngine"  
                let _evaluationDate = Helper.toCell<Date> evaluationDate "evaluationDate"  
                let builder () = withMnemonic mnemonic (Fun.Loan 
                                                            _legs.cell 
                                                            _pricingEngine.cell 
                                                            _evaluationDate.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Loan>) l

                let source = Helper.sourceFold "Fun.Loan" 
                                               [| _legs.source
                                               ;  _pricingEngine.source
                                               ;  _evaluationDate.source
                                               |]
                let hash = Helper.hashFold 
                                [| _legs.cell
                                ;  _pricingEngine.cell
                                ;  _evaluationDate.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<Loan> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_Loan_CASH", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_CASH
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Loan",Description = "Reference to Loan")>] 
         loan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Loan = Helper.toCell<Loan> loan "Loan"  
                let builder () = withMnemonic mnemonic ((_Loan.cell :?> LoanModel).CASH
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Loan.source + ".CASH") 
                                               [| _Loan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Loan.cell
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
    [<ExcelFunction(Name="_Loan_errorEstimate", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_errorEstimate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Loan",Description = "Reference to Loan")>] 
         loan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Loan = Helper.toCell<Loan> loan "Loan"  
                let builder () = withMnemonic mnemonic ((_Loan.cell :?> LoanModel).ErrorEstimate
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Loan.source + ".ErrorEstimate") 
                                               [| _Loan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Loan.cell
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
    [<ExcelFunction(Name="_Loan_NPV", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_NPV
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Loan",Description = "Reference to Loan")>] 
         loan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Loan = Helper.toCell<Loan> loan "Loan"  
                let builder () = withMnemonic mnemonic ((_Loan.cell :?> LoanModel).NPV
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_Loan.source + ".NPV") 
                                               [| _Loan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Loan.cell
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
    [<ExcelFunction(Name="_Loan_result", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_result
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Loan",Description = "Reference to Loan")>] 
         loan : obj)
        ([<ExcelArgument(Name="tag",Description = "Reference to tag")>] 
         tag : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Loan = Helper.toCell<Loan> loan "Loan"  
                let _tag = Helper.toCell<string> tag "tag" 
                let builder () = withMnemonic mnemonic ((_Loan.cell :?> LoanModel).Result
                                                            _tag.cell 
                                                       ) :> ICell
                let format (o : obj) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Loan.source + ".Result") 
                                               [| _Loan.source
                                               ;  _tag.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Loan.cell
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
    [<ExcelFunction(Name="_Loan_setPricingEngine", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_setPricingEngine
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Loan",Description = "Reference to Loan")>] 
         loan : obj)
        ([<ExcelArgument(Name="e",Description = "Reference to e")>] 
         e : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Loan = Helper.toCell<Loan> loan "Loan"  
                let _e = Helper.toCell<IPricingEngine> e "e" 
                let builder () = withMnemonic mnemonic ((_Loan.cell :?> LoanModel).SetPricingEngine
                                                            _e.cell 
                                                       ) :> ICell
                let format (o : Loan) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_Loan.source + ".SetPricingEngine") 
                                               [| _Loan.source
                                               ;  _e.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Loan.cell
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
    [<ExcelFunction(Name="_Loan_valuationDate", Description="Create a Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_valuationDate
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Loan",Description = "Reference to Loan")>] 
         loan : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _Loan = Helper.toCell<Loan> loan "Loan"  
                let builder () = withMnemonic mnemonic ((_Loan.cell :?> LoanModel).ValuationDate
                                                       ) :> ICell
                let format (d : Date) (l:string) = d.serialNumber() :> obj

                let source = Helper.sourceFold (_Loan.source + ".ValuationDate") 
                                               [| _Loan.source
                                               |]
                let hash = Helper.hashFold 
                                [| _Loan.cell
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
    [<ExcelFunction(Name="_Loan_Range", Description="Create a range of Loan",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let Loan_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the Loan")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<Loan> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<Loan>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<Loan>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<Loan>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
