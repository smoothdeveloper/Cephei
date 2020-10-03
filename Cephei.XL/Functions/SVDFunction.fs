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
  Refer to Golub and Van Loan: Matrix computation, The Johns Hopkins University Press  the correctness of the returned values is tested by checking their properties.
  </summary> *)
[<AutoSerializable(true)>]
module SVDFunction =

    (*
        
    *)
    [<ExcelFunction(Name="_SVD_cond", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_cond
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).Cond
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVD.source + ".Cond") 
                                               [| _SVD.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
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
    [<ExcelFunction(Name="_SVD_norm2", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_norm2
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).Norm2
                                                       ) :> ICell
                let format (o : double) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVD.source + ".Norm2") 
                                               [| _SVD.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
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
    [<ExcelFunction(Name="_SVD_rank", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_rank
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).Rank
                                                       ) :> ICell
                let format (o : int) (l:string) = o :> obj

                let source = Helper.sourceFold (_SVD.source + ".Rank") 
                                               [| _SVD.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
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
    [<ExcelFunction(Name="_SVD_S", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_S
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).S
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SVD.source + ".S") 
                                               [| _SVD.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVD> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVD_singularValues", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_singularValues
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).SingularValues
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SVD.source + ".SingularValues") 
                                               [| _SVD.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVD> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVD_solveFor", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_solveFor
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        ([<ExcelArgument(Name="b",Description = "Reference to b")>] 
         b : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let _b = Helper.toCell<Vector> b "b" 
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).SolveFor
                                                            _b.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Vector>) l

                let source = Helper.sourceFold (_SVD.source + ".SolveFor") 
                                               [| _SVD.source
                                               ;  _b.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
                                ;  _b.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVD> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVD", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_create
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="M",Description = "Reference to M")>] 
         M : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _M = Helper.toCell<Matrix> M "M" 
                let builder () = withMnemonic mnemonic (Fun.SVD 
                                                            _M.cell 
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<SVD>) l

                let source = Helper.sourceFold "Fun.SVD" 
                                               [| _M.source
                                               |]
                let hash = Helper.hashFold 
                                [| _M.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVD> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVD_U", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_U
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).U
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SVD.source + ".U") 
                                               [| _SVD.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVD> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    (*
        
    *)
    [<ExcelFunction(Name="_SVD_V", Description="Create a SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_V
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="SVD",Description = "Reference to SVD")>] 
         svd : obj)
        = 
        if not (Model.IsInFunctionWizard()) then

            try

                let _SVD = Helper.toCell<SVD> svd "SVD"  
                let builder () = withMnemonic mnemonic ((_SVD.cell :?> SVDModel).V
                                                       ) :> ICell
                let format (i : ICell) (l:string) = Helper.Range.fromModel (i :?> ICell<Matrix>) l

                let source = Helper.sourceFold (_SVD.source + ".V") 
                                               [| _SVD.source
                                               |]
                let hash = Helper.hashFold 
                                [| _SVD.cell
                                |]
                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModel<SVD> format
                    ; source = source 
                    ; hash = hash
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"
    [<ExcelFunction(Name="_SVD_Range", Description="Create a range of SVD",Category="Cephei", IsThreadSafe = true, IsExceptionSafe=true)>]
    let SVD_Range 
        ([<ExcelArgument(Name="Mnemonic",Description = "Identifer for the value")>] 
         mnemonic : string)
        ([<ExcelArgument(Name="Objects",Description = "Identifer for the SVD")>] 
         values : obj[,])
         =

        if not (Model.IsInFunctionWizard()) then

            try

                let a = values |>
                        Seq.cast<obj> |>
                        Seq.map (fun (i : obj) -> Helper.toCell<SVD> i "value" ) |>
                        Seq.toArray
                let c = a |> Array.map (fun i -> i.cell)
                let l = new Generic.List<ICell<SVD>> (c)
                let s = a |> Array.map (fun i -> i.source)
                let builder () = Util.value l :> ICell
                let format (i : Generic.List<ICell<SVD>>) (l : string) = Helper.Range.fromModelList i l

                Model.specify 
                    { mnemonic = mnemonic
                    ; creator = builder
                    ; subscriber = Helper.subscriberModelRange format
                    ; source = "cell Generic.List<SVD>(" + (Helper.sourceFoldArray (s) + ")")
                    ; hash = Helper.hashFold2 c
                    } :?> string
            with
            | _ as e ->  "#" + e.Message
        else
            "<WIZ>"