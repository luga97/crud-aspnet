
using BrandsCrud.Models;
using BrandsCrud.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BrandsCrud.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsRepository _BrandsRepository;

        public BrandsController(IBrandsRepository brandsRepository)
        {
            _BrandsRepository = brandsRepository;
        }

        public IActionResult Index()
        {
            List<BrandModel> brands = _BrandsRepository.FindAll();

            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            BrandModel brand = _BrandsRepository.FindById(id);
            return View(brand);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            BrandModel brand = _BrandsRepository.FindById(id);
            return View(brand);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _BrandsRepository.Delete(id);

                if(apagado) TempData["MensagemSucesso"] = "Marca apagada com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar sua marca, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar sua marca, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(BrandModel brand)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    brand = _BrandsRepository.Add(brand);
                    TempData["MensagemSucesso"] = "Marca cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(brand);
            }
            catch (Exception exception)
            { 
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar sua marca, tente novamante, detalhe do erro: {exception.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(BrandModel brand)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    brand = _BrandsRepository.Update(brand);
                    TempData["MensagemSucesso"] = "Marca alterada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(brand);
            }
            catch (Exception exception)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar sua marca, tente novamante, detalhe do erro: {exception.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
