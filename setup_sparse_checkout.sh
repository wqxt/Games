#!/bin/bash

# Проверка, что скрипт запускается из корневой директории Git репозитория
if [ ! -d ".git" ]; then
    echo "Этот скрипт нужно запускать из корневой директории Git репозитория."
    exit 1
fi

# Инициализация сабмодулей
echo "Инициализация сабмодулей..."
git submodule update --init --recursive

read -p "Введите имя ветки для сабмодуля IdleRpg (по умолчанию 'main'): " idle_branch
idle_branch=${idle_branch:-main}  

echo "Инициализация sparse-checkout и переключение на ветку '$idle_branch' для сабмодуля IdleRpg..."
cd Assets/ExternalGames/IdleRpg || exit
git checkout "$idle_branch" || git checkout -b "$idle_branch"  
git pull origin "$idle_branch"  
git sparse-checkout init --cone                      
git sparse-checkout set Assets/_IdleRpgGame                            
cd -

read -p "Введите имя ветки для сабмодуля Platformer (по умолчанию 'main'): " platformer_branch
platformer_branch=${platformer_branch:-main}  

echo "Инициализация sparse-checkout и переключение на ветку '$platformer_branch' для сабмодуля Platformer..."
cd Assets/ExternalGames/Platformer || exit
git checkout "$platformer_branch" || git checkout -b "$platformer_branch" 
git pull origin "$platformer_branch"  
git sparse-checkout init --cone                     
git sparse-checkout set Assets/_Platformer 
cd -

echo "Обновление сабмодулей..."
git submodule update --remote --recursive       
echo "Сабмодули успешно настроены!"
