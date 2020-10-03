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
module MTLCurrencyFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_MTLCurrency", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let builder () = withMnemonic mnemonic (Fun.MTLCurrency ()
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<MTLCurrency>) l

                let source = Helper.sourceFold "Fun.MTLCurrency" 
                                               [||]
                let hash = Helper.hashFold 
                                [||]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MTLCurrency> format
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
    [<ExcelFunction(Name="_MTLCurrency_code", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_code
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).Code
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".Code") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_empty", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_empty
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).Empty
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".Empty") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_Equals", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_Equals
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        ([<ExcelArgument(Name="o",Description = "Reference to o")>] 
         o : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let _o = Helper.toCell<Object> o "o" 
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).Equals
                                                            _o.cell 
                                                       ) :> ICell
                let format (o : bool) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".Equals") 
                                               [| _MTLCurrency.source
                                               ;  _o.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_format", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_format
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).Format
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".Format") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_fractionsPerUnit", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_fractionsPerUnit
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).FractionsPerUnit
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".FractionsPerUnit") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_fractionSymbol", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_fractionSymbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).FractionSymbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".FractionSymbol") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_name", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_name
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).Name
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".Name") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_numericCode", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_numericCode
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).NumericCode
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".NumericCode") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_rounding", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_rounding
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).Rounding
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Rounding>) l

                let source = Helper.sourceFold (_MTLCurrency.source + ".Rounding") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MTLCurrency> format
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
    [<ExcelFunction(Name="_MTLCurrency_symbol", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_symbol
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).Symbol
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".Symbol") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_ToString", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_ToString
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).ToString
                                                       ) :> ICell
                let format (o : string) (l:string) = o.ToString() :> obj

                let source = Helper.sourceFold (_MTLCurrency.source + ".ToString") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
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
    [<ExcelFunction(Name="_MTLCurrency_triangulationCurrency", Description="Create a MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_triangulationCurrency
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="MTLCurrency",Description = "Reference to MTLCurrency")>] 
         mtlcurrency : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _MTLCurrency = Helper.toCell<MTLCurrency> mtlcurrency "MTLCurrency"  
                let builder () = withMnemonic mnemonic ((_MTLCurrency.cell :?> MTLCurrencyModel).TriangulationCurrency
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Currency>) l

                let source = Helper.sourceFold (_MTLCurrency.source + ".TriangulationCurrency") 
                                               [| _MTLCurrency.source
                                               |]
                let hash = Helper.hashFold 
                                [| _MTLCurrency.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<MTLCurrency> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_MTLCurrency_Range", Description="Create a range of MTLCurrency",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let MTLCurrency_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the MTLCurrency")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<MTLCurrency> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<MTLCurrency>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<MTLCurrency>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<MTLCurrency>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"