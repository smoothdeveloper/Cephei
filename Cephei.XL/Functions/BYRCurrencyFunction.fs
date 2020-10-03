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
module BYRCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_BYRCurrency", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.BYRCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<BYRCurrency>) l

                let source = Helper.sourceFold "Fun.BYRCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BYRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! currency name, e.g, "U.S. Dollar"
    *)
    [<ExcelFunction(Name="_BYRCurrency_code", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".Code") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
        ! Other information ! is this a usable instance?
    *)
    [<ExcelFunction(Name="_BYRCurrency_empty", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".Empty") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
    [<ExcelFunction(Name="_BYRCurrency_Equals", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".Equals") 
                                               [| _BYRCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
        ! currency used for triangulated exchange when required output format The format will be fed three positional parameters, namely, value, code, and symbol, in this order.
    *)
    [<ExcelFunction(Name="_BYRCurrency_format", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".Format") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
        ! fraction symbol, e.g, "Â¢"
    *)
    [<ExcelFunction(Name="_BYRCurrency_fractionsPerUnit", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".FractionsPerUnit") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
        ! symbol, e.g, "$"
    *)
    [<ExcelFunction(Name="_BYRCurrency_fractionSymbol", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".FractionSymbol") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
    [<ExcelFunction(Name="_BYRCurrency_name", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".Name") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
        ! ISO 4217 three-letter code, e.g, "USD"
    *)
    [<ExcelFunction(Name="_BYRCurrency_numericCode", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".NumericCode") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
        ! number of fractionary parts in a unit, e.g, 100
    *)
    [<ExcelFunction(Name="_BYRCurrency_rounding", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_BYRCurrency.source + ".Rounding") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BYRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        ! ISO 4217 numeric code, e.g, "840"
    *)
    [<ExcelFunction(Name="_BYRCurrency_symbol", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".Symbol") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
    [<ExcelFunction(Name="_BYRCurrency_ToString", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_BYRCurrency.source + ".ToString") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
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
        ! rounding convention
    *)
    [<ExcelFunction(Name="_BYRCurrency_triangulationCurrency", Description="Create a BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="BYRCurrency",Description = "Reference to BYRCurrency")>] 
         byrcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _BYRCurrency = Helper.toCell<BYRCurrency> byrcurrency "BYRCurrency"  
                let builder () = withMnemonic mnemonic ((_BYRCurrency.cell :?> BYRCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_BYRCurrency.source + ".TriangulationCurrency") 
                                               [| _BYRCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _BYRCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<BYRCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_BYRCurrency_Range", Description="Create a range of BYRCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let BYRCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the BYRCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<BYRCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<BYRCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<BYRCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<BYRCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"